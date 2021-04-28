using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Comments
{
    public partial class CommentService
    {
        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Comment> AddComment(Comment pComment)
        {
            try
            {
                await _dbContext.AddAsync(pComment).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return pComment;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return null;
            }
        }
    }
}
