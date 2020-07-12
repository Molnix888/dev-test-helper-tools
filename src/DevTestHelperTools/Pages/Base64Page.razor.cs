using DevTestHelperTools.Models;
using DevTestHelperTools.Services;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Base64 page.
    /// </summary>
    public partial class Base64Page
    {
        private string _result;

        /// <summary>
        /// Gets or sets Base64 model values.
        /// </summary>
        public Base64Model Base64 { get; set; } = new Base64Model();

        /// <summary>
        /// Encodes input string to Base64 format.
        /// </summary>
        public void Encode() => _result = Base64Service.EncodeString(Base64.InputString);

        /// <summary>
        /// Decodes input string from Base64 format.
        /// </summary>
        public void Decode() => _result = Base64Service.DecodeString(Base64.InputString);
    }
}
