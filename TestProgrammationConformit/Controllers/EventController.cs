using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Helper;
using TestProgrammationConformit.Interfaces;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Reponse.Pagination;
using TestProgrammationConformit.Request.Pagination;

namespace TestProgrammationConformit.Controllers
{
    /// <summary>
    /// Event Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The event service
        /// </summary>
        private readonly IEventService _eventService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventController"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="eventService">The event service.</param>
        /// <exception cref="ArgumentException">eventService</exception>
        public EventController(ILoggerFactory loggerFactory, IEventService eventService)
        {
            _logger = loggerFactory?.CreateLogger("Event Controller");
            _eventService = eventService ?? throw new ArgumentException(nameof(eventService));
        }

        /// <summary>
        /// Gets the events asynchronous.
        /// </summary>
        /// <param name="paginationRequest">The pagination request.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("events")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericPaginationResult<Event>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventsAsync([FromQuery] PaginationRequest paginationRequest)
        {
            try
            {
                GenericPaginationResult<Event> result = null;
                result = await _eventService.GetEvents(paginationRequest).ConfigureAwait(false);
                return result == null || result.Response == null ? (IActionResult)NoContent() : Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("event/create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Event))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddEvent([FromBody] Event pEvent)
        {
            if (pEvent == null)
                return BadRequest();

            try
            {
                Event result = await _eventService.AddEvent(pEvent).ConfigureAwait(false);
                return result == null ? (IActionResult)NoContent() : StatusCode(201, Constant.CreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("event/update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Event))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEvent([FromQuery] int eventId, [FromBody] Event pEvent)
        {
            if (pEvent == null)
                return BadRequest();

            try
            {
                Event result = await _eventService.UpdateEvent(eventId, pEvent).ConfigureAwait(false);
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
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("event/remove")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveEvent([FromQuery] int eventId)
        {
            if (eventId <= 0)
                return BadRequest();

            try
            {
                bool result = await _eventService.DeleteEvent(eventId).ConfigureAwait(false);
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