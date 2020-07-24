using DevTestHelperTools.Services.Abstraction;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace DevTestHelperTools.Test.Unit.Services
{
    /// <summary>
    /// Contains tests for Hash service methods.
    /// </summary>
    [TestFixture]
    public class HashServiceTests
    {
        private readonly IHashService _hashService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashServiceTests"/> class.
        /// </summary>
        /// <param name="hashService">Hash service.</param>
        public HashServiceTests(IHashService hashService) => _hashService = hashService;

        /// <summary>
        /// Tests GetHashTypes method.
        /// </summary>
        [Test]
        public void GetHashTypesSuccess()
        {
            var hashTypes = _hashService.GetHashTypes();

            using (new AssertionScope())
            {
                _ = hashTypes.Count.Should().Be(6);

                foreach (var type in hashTypes)
                {
                    _ = type.Key.Should().BeNullOrWhiteSpace();
                    _ = type.Value.Should().BeNullOrWhiteSpace();
                }
            }
        }
    }
}
