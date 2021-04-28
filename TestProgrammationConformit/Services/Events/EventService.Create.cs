using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Events
{
    public partial class EventService
    {
        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="pEvent">The p event.</param>
        /// <returns></returns>
        public async Task<Event> AddEvent(Event pEvent)
        {
            try
            {
                await _dbContext.AddAsync(pEvent).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return pEvent;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return null;
            }
        }
    }
}
