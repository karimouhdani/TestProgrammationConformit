using Microsoft.Extensions.Configuration;
using TestProgrammationConformit.Request.Pagination;

namespace TestProgrammationConformit.Helper
{
    public static class PaginationHelper
    {
        /// <summary>
        /// Computes the pagination values.
        /// </summary>
        /// <param name="paginationRequest">The pagination request.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static (int, int, int) ComputePaginationValues(PaginationRequest paginationRequest, IConfiguration configuration)
        {
            const string paginationSection = Constant.PaginationSection;
            const string limitSubSection = Constant.LimitSubSection;

            const int defaultLimit = Constant.DefaultLimit;

            int defaultConfigLimit = configuration.GetConfigAsInt(paginationSection, limitSubSection, defaultLimit);

            paginationRequest?.CheckParamsValue(defaultConfigLimit);
            var page = paginationRequest?.Page;
            var limit = paginationRequest?.Limit;

            int offset = Offset(page.Value, limit.Value);

            return (page.Value, limit.Value, offset);
        }

        /// <summary>
        /// Offsets the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        internal static int Offset(int page, int limit) => (page - 1) * limit;
    }
}
