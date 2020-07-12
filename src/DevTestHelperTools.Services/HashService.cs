using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using DevTestHelperTools.Utils.Extensions;

namespace DevTestHelperTools.Services
{
    /// <summary>
    /// Provides functionality for hashing operations.
    /// </summary>
    public static class HashService
    {
        /// <summary>
        /// Gets the array of hash types.
        /// </summary>
        public static IEnumerable<string> HashTypes => new[]
        {
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512",
            "MD5",
            "RIPEMD160",
        };

        /// <summary>
        /// Computes hash for a provided input via selected algorithm.
        /// </summary>
        /// <param name="algorithmName">Name of hashing algorithm to apply.</param>
        /// <param name="input">Input string for hashing.</param>
        /// <returns>Computed hash string.</returns>
        public static string ComputeHash(string algorithmName, string input)
        {
            using var algorithm = HashAlgorithm.Create(algorithmName);

            return GetHash(algorithm, input);
        }

        private static string GetHash(HashAlgorithm algorithm, string input)
        {
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input.ResolveInput()));

            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                _ = sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}
