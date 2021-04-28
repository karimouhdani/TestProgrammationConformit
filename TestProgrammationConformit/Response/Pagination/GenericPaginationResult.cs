using System.Text.Json.Serialization;

namespace TestProgrammationConformit.Reponse.Pagination
{
    /// <summary>
    /// Generic Pagination Result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericPaginationResult<T>
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [JsonPropertyName("response")]
        public BaseResponse<T> Response { get; set; }
    }
}
