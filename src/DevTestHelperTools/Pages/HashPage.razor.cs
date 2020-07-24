using DevTestHelperTools.Elements;
using DevTestHelperTools.Models;
using DevTestHelperTools.Services.Abstraction;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Hash page.
    /// </summary>
    public partial class HashPage
    {
        private readonly HashModel _hash;
        private readonly IHashService _hashService;
        private string _result;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashPage"/> class.
        /// </summary>
        /// <param name="hash">Hash model.</param>
        /// <param name="hashService">Hash service.</param>
        public HashPage(HashModel hash, IHashService hashService)
        {
            _hash = hash;
            _hashService = hashService;
        }

        /// <summary>
        /// Gets or sets select menu parameters.
        /// </summary>
        public SelectMenu SelectMenu { get; set; } = new SelectMenu();

        /// <summary>
        /// Computes hash for specified input and sets the result value.
        /// </summary>
        public void ComputeHash() => _result = _hashService.ComputeHash(_hash.Algorithm, _hash.InputString);
    }
}
