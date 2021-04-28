using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Comments
{
    public partial class CommentService
    {
        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Comment> UpdateComment(int commentId, Comment pComment)
        {
            try
            {
                Comment result = await _dbContext.Comments.FindAsync(commentId).ConfigureAwait(false);
                if (result != null)
                {
                    result.Description = pComment.Description;
                    result.CommentDate = DateTime.Now;
                    await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                    return result;
                }
                return null;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return null;
            }
        }
    }
}
