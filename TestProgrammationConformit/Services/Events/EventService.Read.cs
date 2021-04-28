using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Helper;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Reponse.Pagination;
using TestProgrammationConformit.Request.Pagination;

namespace TestProgrammationConformit.Services.Events
{
    public partial class EventService
    {
        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <param name="paginationRequest">The pagination request.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<GenericPaginationResult<Event>> GetEvents(PaginationRequest paginationRequest)
        {
            (int currentPage, int limit, int skip) = PaginationHelper.ComputePaginationValues(paginationRequest, _configuration);

            IEnumerable<Event> events = await _dbContext.Events.Include(i => i.Comments).ToListAsync().ConfigureAwait(false);

            double totatDocuments = events.Count();

            IEnumerable<Event> result = events.Skip(skip).Take(limit).ToList();

            int totatlPages = (int)Math.Ceiling(totatDocuments / limit);

            return new GenericPaginationResult<Event>
            {
                Response = new BaseResponse<Event>(currentPage, result.Count(), totatlPages, (int)totatDocuments, result)
            };
        }
    }
}
