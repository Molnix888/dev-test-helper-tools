using System.Collections.Generic;

namespace DevTestHelperTools.Services.Abstraction
{
    /// <summary>
    /// Provides functionality for hashing operations.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Gets the dictionary of hash types.
        /// </summary>
        /// <returns>Key-value pair of hash types.</returns>
        IDictionary<string, string> GetHashTypes();

        /// <summary>
        /// Computes hash for a provided input via selected algorithm.
        /// </summary>
        /// <param name="algorithmName">Name of hashing algorithm to apply.</param>
        /// <param name="input">Input string for hashing.</param>
        /// <returns>Computed hash string.</returns>
        string ComputeHash(string algorithmName, string input);
    }
}
