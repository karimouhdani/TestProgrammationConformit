using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services.Events
{
    public partial class EventService
    {
        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                Event result = await _dbContext.Events.FindAsync(eventId).ConfigureAwait(false);
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
