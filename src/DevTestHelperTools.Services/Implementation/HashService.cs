using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using DevTestHelperTools.Services.Abstraction;
using DevTestHelperTools.Utils.Extensions;

namespace DevTestHelperTools.Services.Implementation
{
    /// <inheritdoc cref="IHashService"/>
    public class HashService : IHashService
    {
        /// <inheritdoc/>
        public IDictionary<string, string> GetHashTypes()
        {
            var md5 = "MD5"; // DevSkim: ignore DS126858

            return new Dictionary<string, string>
            {
                { "SHA-1", "SHA1" }, // DevSkim: ignore DS126858
                { "SHA-256", "SHA256" },
                { "SHA-384", "SHA384" },
                { "SHA-512", "SHA512" },
                { md5, md5 },
                { "RIPEMD-160", "RIPEMD160" }, // DevSkim: ignore DS126858
            };
        }

        /// <inheritdoc/>
        public string ComputeHash(string algorithmName, string input)
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
