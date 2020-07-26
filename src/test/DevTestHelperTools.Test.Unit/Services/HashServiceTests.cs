using System.Collections.Generic;
using DevTestHelperTools.Services.Abstraction;
using DevTestHelperTools.Services.DI;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
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
        public HashServiceTests() => _hashService = new ServiceCollection()
            .AddHashService()
            .BuildServiceProvider()
            .GetService<IHashService>();

        /// <summary>
        /// Tests GetHashTypes method.
        /// </summary>
        [Test]
        public void GetHashTypesSuccess()
        {
            var hashTypes = _hashService.GetHashTypes();

            using (new AssertionScope())
            {
                _ = hashTypes.Count.Should().Be(5);

                foreach (var type in hashTypes)
                {
                    _ = type.Key.Should().NotBeNullOrWhiteSpace();
                    _ = type.Value.Should().NotBeNullOrWhiteSpace();
                }
            }
        }

        /// <summary>
        /// Tests ComputeHash method.
        /// </summary>
        /// <param name="algorithmName">Hashing Algorithm.</param>
        /// <param name="input">Input string.</param>
        /// <param name="expected">Expected hashing result.</param>
        [Test]
        [TestCaseSource(nameof(GetHashingTestData))]
        public void ComputeHashFromInputStringSuccess(string algorithmName, string input, string expected) => _hashService.ComputeHash(algorithmName, input).Should().Be(expected);

        private static IEnumerable<object[]> GetHashingTestData()
        {
            var whitespace = " ";

            yield return new object[] { null, "a", string.Empty };
            yield return new object[] { string.Empty, "b", string.Empty };
            yield return new object[] { whitespace, "c", string.Empty };
            yield return new object[] { "invalid", "d", string.Empty };
            yield return new object[] { "SHA1", null, "da39a3ee5e6b4b0d3255bfef95601890afd80709" }; // DevSkim: ignore DS173237,DS126858
            yield return new object[] { "MD5", string.Empty, "d41d8cd98f00b204e9800998ecf8427e" }; // DevSkim: ignore DS173237,DS126858
            yield return new object[] { "SHA256", whitespace, "36a9e7f1c95b82ffb99743e0c5c4ce95d83c9a430aac59f84ef3cbfab6145068" }; // DevSkim: ignore DS173237
            yield return new object[] { "SHA384", "1", "47f05d367b0c32e438fb63e6cf4a5f35c2aa2f90dc7543f8a41a0f95ce8a40a313ab5cf36134a2068c4c969cb50db776" }; // DevSkim: ignore DS173237
            yield return new object[] { "SHA512", "!", "3831a6a6155e509dee59a7f451eb35324d8f8f2df6e3708894740f98fdee23889f4de5adb0c5010dfb555cda77c8ab5dc902094c52de3278f35a75ebc25f093a" }; // DevSkim: ignore DS173237
        }
    }
}
