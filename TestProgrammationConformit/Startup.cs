using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestProgrammationConformit.Controllers;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Interfaces;
using TestProgrammationConformit.Services.Comments;
using TestProgrammationConformit.Services.Events;

namespace TestProgrammationConformit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ConformitContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConformitDb"),
                    npgsqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    });
            });

            services.AddSwaggerGen();

            var serviceProvider = services.BuildServiceProvider();
            var loggerComment = serviceProvider.GetService<ILogger<CommentController>>();
            var lohggerEvent = serviceProvider.GetService<ILogger<EventController>>();
            services.AddSingleton(typeof(ILogger), loggerComment);
            services.AddSingleton(typeof(ILogger), lohggerEvent);


            services.AddTransient<IEventService, EventService>()
                    .AddTransient<ICommentService, CommentService>();
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddMvcCore().AddJsonOptions(j =>
            {
                j.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
