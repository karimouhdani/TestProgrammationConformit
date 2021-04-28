using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Events
{
    public partial class EventService
    {
        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        public async Task<Event> UpdateEvent(int eventId, Event pEvent)
        {
            try
            {
                Event result = await _dbContext.Events.FindAsync(eventId).ConfigureAwait(false);
                if (result != null)
                {
                    result.Title = pEvent.Title;
                    result.Person.Id = pEvent.Person.Id;
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
