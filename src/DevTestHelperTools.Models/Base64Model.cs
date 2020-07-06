namespace DevTestHelperTools.Models
{
    /// <summary>
    /// Model for Base64 encoding/decoding.
    /// </summary>
    public class Base64Model
    {
        /// <summary>
        /// Gets or sets Base64 encoded text.
        /// </summary>
        public string EncodedText { get; set; }

        /// <summary>
        /// Gets or sets decoded text.
        /// </summary>
        public string DecodedText { get; set; }
    }
}
