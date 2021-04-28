using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestProgrammationConformit.Reponse.Pagination
{
    /// <summary>
    /// BaseResponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the count items per page.
        /// </summary>
        /// <value>
        /// The count items per page.
        /// </value>
        [JsonPropertyName("countItemsPerPage")]
        public int CountItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        /// <value>
        /// The total items.
        /// </value>
        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse{T}" /> class.
        /// </summary>
        public BaseResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="countItemsPerPage">The count items per page.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="items">The items.</param>
        public BaseResponse(int? currentPage, int countItemsPerPage, int totalPages, int totalItems, IEnumerable<T> items)
        {
            CurrentPage = currentPage ?? 1;
            CountItemsPerPage = countItemsPerPage;
            TotalPages = totalPages > 0 ? totalPages : 1;
            TotalItems = totalItems;
            Items = items;
        }
    }
}
