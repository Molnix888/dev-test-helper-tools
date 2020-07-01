﻿using System.ComponentModel.DataAnnotations;

namespace DevTestHelperTools.Models
{
    /// <summary>
    /// Model for hash calculation.
    /// </summary>
    public class HashModel
    {
        /// <summary>
        /// Gets or sets hash algorithm value.
        /// </summary>
        [Required]
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets input string for hash calculation.
        /// </summary>
        public string InputString { get; set; }
    }
}
