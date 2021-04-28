using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Interfaces;

namespace TestProgrammationConformit.Services.Events
{
    /// <summary>
    /// Event Service
    /// </summary>
    /// <seealso cref="TestProgrammationConformit.Interfaces.IEventService" />
    public partial class EventService : IEventService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ConformitContext _dbContext;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">
        /// dbContext
        /// or
        /// configuration
        /// or
        /// logger
        /// </exception>
        public EventService(ConformitContext dbContext, IConfiguration configuration, ILogger logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
