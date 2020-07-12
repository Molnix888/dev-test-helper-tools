namespace DevTestHelperTools.Utils.Extensions
{
    /// <summary>
    /// Provides string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Resolves null input.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Not null string.</returns>
        public static string ResolveInput(this string value) => value ?? string.Empty;
    }
}
