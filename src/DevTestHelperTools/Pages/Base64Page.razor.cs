// <copyright file="Base64Page.razor.cs" company="Eugene Klimeshuk (Molnix888)">
// Copyright (c) Eugene Klimeshuk (Molnix888). All rights reserved.
// </copyright>

using System;
using System.Text;
using DevTestHelperTools.Models;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Base64 page.
    /// </summary>
    public partial class Base64Page
    {
        /// <summary>
        /// Gets or sets Base64 model values.
        /// </summary>
        public Base64Model Base64 { get; set; } = new Base64Model();

        /// <summary>
        /// Encodes input string to Base64 format.
        /// </summary>
        public void Encode() => Base64.EncodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(Base64.DecodedText ?? string.Empty));

        /// <summary>
        /// Decodes input string from Base64 format.
        /// </summary>
        public void Decode() => Base64.DecodedText = Convert.TryFromBase64String(
                Base64.EncodedText,
                new byte[((Base64.EncodedText.Length * 3) + 3) / 4],
                out _)
                                    ? Encoding.UTF8.GetString(Convert.FromBase64String(Base64.EncodedText ?? string.Empty))
                                    : "The provided input not in Base64 format.";
    }
}
