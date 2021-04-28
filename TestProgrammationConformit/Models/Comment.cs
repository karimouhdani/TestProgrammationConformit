using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestProgrammationConformit.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the comment date.
        /// </summary>
        /// <value>
        /// The comment date.
        /// </value>
        [JsonPropertyName("commentDate")]
        public DateTime CommentDate { get; set; }

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        [JsonPropertyName("event")]
        [Required]
        public Event Event { get; set; }
    }
}
