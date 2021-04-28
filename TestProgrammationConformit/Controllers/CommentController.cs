using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Helper;
using TestProgrammationConformit.Interfaces;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Controllers
{
    /// <summary>
    /// Event Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class CommentController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The comment service
        /// </summary>
        private readonly ICommentService _commentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="commentService">The comment service.</param>
        /// <exception cref="ArgumentException">commentService</exception>
        public CommentController(ILoggerFactory loggerFactory, ICommentService commentService)
        {
            _logger = loggerFactory?.CreateLogger("Comment Controller");
            _commentService = commentService ?? throw new ArgumentException(nameof(commentService));
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("comment/create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Comment))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddComment([FromBody] Comment pComment)
        {
            if (pComment == null)
                return BadRequest();

            try
            {
                Comment result = await _commentService.AddComment(pComment).ConfigureAwait(false);
                return result == null ? (IActionResult)NoContent() : StatusCode(201, Constant.CreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="pComment">The p comment.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("comment/update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Comment))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEvent([FromQuery] int commentId, [FromBody] Comment pComment)
        {
            if (pComment == null)
                return BadRequest();

            try
            {
                Comment result = await _commentService.UpdateComment(commentId, pComment).ConfigureAwait(false);
                return result == null ? (IActionResult)NoContent() : Ok(Constant.UpdateddSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Removes the event.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("comment/remove")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveEvent([FromQuery] int commentId)
        {
            if (commentId <= 0)
                return BadRequest();

            try
            {
                bool result = await _commentService.DeleteComment(commentId).ConfigureAwait(false);
                return !result ? (IActionResult)NoContent() : StatusCode(202, Constant.DeletedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}