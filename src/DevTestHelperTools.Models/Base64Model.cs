using System.ComponentModel.DataAnnotations;

namespace DevTestHelperTools.Models
{
    /// <summary>
    /// Model for Base64 encoding/decoding.
    /// </summary>
    public class Base64Model
    {
        /// <summary>
        /// Gets or sets input string for encoding/decoding.
        /// </summary>
        [Required]
        public string InputString { get; set; }
    }
}
