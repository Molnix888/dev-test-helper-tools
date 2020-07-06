using System;
using System.Text;

namespace DevTestHelperTools.Services
{
    /// <summary>
    /// Provides functionality for work with Base64 format.
    /// </summary>
    public static class Base64Service
    {
        /// <summary>
        /// Encodes input string to Base64 format.
        /// </summary>
        /// <param name="input">Input string for encoding.</param>
        /// <returns>Encoded string.</returns>
        public static string EncodeString(string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input ?? string.Empty));

        /// <summary>
        /// Decodes input string from Base64 format.
        /// </summary>
        /// <param name="input">Input string for decoding.</param>
        /// <returns>Decoded string.</returns>
        public static string DecodeString(string input)
        {
            input ??= string.Empty;

            return Convert.TryFromBase64String(input, new byte[input.Length], out _)
                ? Encoding.UTF8.GetString(Convert.FromBase64String(input))
                : "The input not in Base64 format.";
        }
    }
}
