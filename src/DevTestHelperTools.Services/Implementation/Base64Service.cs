using System;
using System.Text;
using DevTestHelperTools.Services.Abstraction;
using DevTestHelperTools.Utils.Extensions;

namespace DevTestHelperTools.Services.Implementation
{
    /// <inheritdoc cref="IBase64Service"/>
    public class Base64Service : IBase64Service
    {
        /// <inheritdoc/>
        public string EncodeString(string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input.ResolveInput()));

        /// <inheritdoc/>
        public string DecodeString(string input)
        {
            input = input.ResolveInput();

            return Convert.TryFromBase64String(input, new byte[input.Length], out _)
                ? Encoding.UTF8.GetString(Convert.FromBase64String(input))
                : null;
        }
    }
}
