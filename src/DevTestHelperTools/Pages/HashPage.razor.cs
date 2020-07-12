using DevTestHelperTools.Elements;
using DevTestHelperTools.Models;
using DevTestHelperTools.Services;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Hash page.
    /// </summary>
    public partial class HashPage
    {
        private string _result;

        /// <summary>
        /// Gets or sets hash model values.
        /// </summary>
        public HashModel Hash { get; set; } = new HashModel();

        /// <summary>
        /// Gets or sets select menu parameters.
        /// </summary>
        public SelectMenu SelectMenu { get; set; } = new SelectMenu();

        /// <summary>
        /// Computes hash for specified input and sets the result value.
        /// </summary>
        public void ComputeHash() => _result = HashService.ComputeHash(Hash.Algorithm, Hash.InputString);
    }
}
