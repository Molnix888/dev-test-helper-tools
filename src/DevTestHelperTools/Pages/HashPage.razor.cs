// <copyright file="HashPage.razor.cs" company="Eugene Klimeshuk (Molnix888)">
// Copyright (c) Eugene Klimeshuk (Molnix888). All rights reserved.
// </copyright>

using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using DevTestHelperTools.Elements;
using DevTestHelperTools.Models;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Hash page.
    /// </summary>
    public partial class HashPage
    {
        private readonly string[] _hashTypes =
        {
            "MD5",
            "RIPEMD160",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512",
        };

        /// <summary>
        /// Gets or sets hash model values.
        /// </summary>
        public HashModel Hash { get; set; } = new HashModel();

        /// <summary>
        /// Gets or sets input source value.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets result value.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets select menu parameters.
        /// </summary>
        public SelectMenu SelectMenu { get; set; } = new SelectMenu();

        /// <summary>
        /// Computes hash for specified input and sets the result value.
        /// </summary>
        public void ComputeHash()
        {
            using var hashAlgorithm = HashAlgorithm.Create(Hash.Algorithm);
            Source = Hash.InputString;
            Result = GetHash(hashAlgorithm, Hash.InputString ?? string.Empty);
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            foreach (var b in data)
            {
                _ = builder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
            }

            return builder.ToString();
        }
    }
}
