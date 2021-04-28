﻿using System.ComponentModel.DataAnnotations;

namespace TestProgrammationConformit.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
