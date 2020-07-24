namespace DevTestHelperTools.Services.Abstraction
{
    /// <summary>
    /// Provides functionality for performing operations with Base64 format.
    /// </summary>
    public interface IBase64Service
    {
        /// <summary>
        /// Encodes input string to Base64 format.
        /// </summary>
        /// <param name="input">Input string for encoding.</param>
        /// <returns>Encoded string.</returns>
        string EncodeString(string input);

        /// <summary>
        /// Decodes input string from Base64 format.
        /// </summary>
        /// <param name="input">Input string for decoding.</param>
        /// <returns>Decoded string.</returns>
        string DecodeString(string input);
    }
}
