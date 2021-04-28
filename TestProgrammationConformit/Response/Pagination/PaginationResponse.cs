using System.Collections.Generic;

namespace TestProgrammationConformit.Reponse.Pagination
{
    /// <summary>
    /// Pagination Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Temp.Crud.Ef.Infrastructure.Pagination.BaseResponse{T}" />
    public class PaginationResponse<T> : BaseResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResponse{T}"/> class.
        /// </summary>
        public PaginationResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResponse{T}"/> class.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="countItemsPerPage">The count items per page.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="items">The items.</param>
        public PaginationResponse(int? currentPage, int countItemsPerPage, int totalPages, int totalItems, IEnumerable<T> items)
            : base(currentPage, countItemsPerPage, totalPages, totalItems, items)
        {
            Items = items;
        }
    }
}
