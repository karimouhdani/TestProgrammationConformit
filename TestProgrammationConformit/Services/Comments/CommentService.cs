using Microsoft.Extensions.Logging;
using System;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Interfaces;

namespace TestProgrammationConformit.Services.Comments
{
    /// <summary>
    /// Comment Service
    /// </summary>
    /// <seealso cref="TestProgrammationConformit.Interfaces.ICommentService" />
    public partial class CommentService : ICommentService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ConformitContext _dbContext;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventService" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">dbContext
        /// or
        /// configuration
        /// or
        /// logger</exception>
        public CommentService(ConformitContext dbContext, ILogger logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
