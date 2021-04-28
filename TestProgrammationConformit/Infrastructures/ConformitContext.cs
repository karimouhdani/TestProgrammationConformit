using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Infrastructures
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ConformitContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConformitContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ConformitContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public virtual DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public virtual DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public virtual DbSet<Event> Events { get; set; }
    }
}
