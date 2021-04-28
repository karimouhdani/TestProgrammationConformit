using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Comments
{
    public partial class CommentService
    {
        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> DeleteComment(int commentId)
        {
            try
            {
                Comment result = await _dbContext.Comments.FindAsync(commentId).ConfigureAwait(false);
                if (result != null)
                {
                    _dbContext.Remove(result);
                    await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return false;
            }
        }
    }
}
