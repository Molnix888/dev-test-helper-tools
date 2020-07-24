using DevTestHelperTools.Models;
using DevTestHelperTools.Services.Abstraction;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Base64 page.
    /// </summary>
    public partial class Base64Page
    {
        private readonly Base64Model _base64;
        private readonly IBase64Service _base64Service;
        private string _result;

        /// <summary>
        /// Initializes a new instance of the <see cref="Base64Page"/> class.
        /// </summary>
        /// <param name="base64">Base64 model.</param>
        /// <param name="base64Service">Base64 service.</param>
        public Base64Page(Base64Model base64, IBase64Service base64Service)
        {
            _base64 = base64;
            _base64Service = base64Service;
        }

        /// <summary>
        /// Encodes input string to Base64 format.
        /// </summary>
        public void Encode() => _result = _base64Service.EncodeString(_base64.InputString);

        /// <summary>
        /// Decodes input string from Base64 format.
        /// </summary>
        public void Decode() => _result = _base64Service.DecodeString(_base64.InputString);
    }
}
