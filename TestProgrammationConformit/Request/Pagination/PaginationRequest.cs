namespace TestProgrammationConformit.Request.Pagination
{
    /// <summary>
    /// Pagination Request
    /// </summary>
    public class PaginationRequest
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public int Limit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationRequest"/> class.
        /// </summary>
        public PaginationRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationRequest"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        public PaginationRequest(int page, int limit)
        {
            Page = page;
            Limit = limit;
        }

        /// <summary>
        /// Checks the parameters value.
        /// </summary>
        /// <param name="defaultLimit">The default limit.</param>
        public void CheckParamsValue(int defaultLimit)
        {
            const int defaultPage = 1;
            if (Page <= 0)
                Page = defaultPage;
            if (Limit <= 0)
                Limit = defaultLimit;
        }
    }
}
