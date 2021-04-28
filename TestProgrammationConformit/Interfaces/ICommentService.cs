using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Interfaces
{
    /// <summary>
    /// Comment Service
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        Task<Comment> AddComment(Comment pComment);

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        Task<Comment> UpdateComment(int commentId, Comment pComment);

        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteComment(int commentId);
    }
}
