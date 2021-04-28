using System.Threading.Tasks;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Reponse.Pagination;
using TestProgrammationConformit.Request.Pagination;

namespace TestProgrammationConformit.Interfaces
{
    /// <summary>
    /// Event Service
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        Task<Event> AddEvent(Event pEvent);

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        Task<Event> UpdateEvent(int eventId, Event pEvent);

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteEvent(int eventId);

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <param name="paginationRequest">The pagination request.</param>
        /// <returns></returns>
        Task<GenericPaginationResult<Event>> GetEvents(PaginationRequest paginationRequest);
    }
}
