using DevTestHelperTools.Models;
using DevTestHelperTools.Services.Abstraction;
using Microsoft.AspNetCore.Components;

namespace DevTestHelperTools.Pages
{
    /// <summary>
    /// Base for building Hash page.
    /// </summary>
    public partial class HashPage
    {
        private string _result;

        [Inject]
        private HashModel Hash { get; set; }

        [Inject]
        private IHashService HashService { get; set; }

        /// <summary>
        /// Computes hash for specified input and sets the result value.
        /// </summary>
        public void ComputeHash() => _result = HashService.ComputeHash(Hash.Algorithm, Hash.InputString);
    }
}
