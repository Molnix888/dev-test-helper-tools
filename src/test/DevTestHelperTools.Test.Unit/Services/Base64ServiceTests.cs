using System.Collections.Generic;
using DevTestHelperTools.Services.Abstraction;
using FluentAssertions;
using NUnit.Framework;

namespace DevTestHelperTools.Test.Unit.Services
{
    /// <summary>
    /// Contains tests for Base64 service methods.
    /// </summary>
    [TestFixture]
    public class Base64ServiceTests
    {
        private readonly IBase64Service _base64Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Base64ServiceTests"/> class.
        /// </summary>
        /// <param name="base64Service">Base64 service.</param>
        public Base64ServiceTests(IBase64Service base64Service) => _base64Service = base64Service;

        /// <summary>
        /// Tests EncodeString method.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="expected">Expected encoding result.</param>
        [Test]
        [TestCaseSource(nameof(GetEncodeTestData))]
        [TestCaseSource(nameof(GetEncodeDecodeTestData))]
        public void EncodeInputStringSuccess(string input, string expected) => _base64Service.EncodeString(input).Should().Be(expected);

        /// <summary>
        /// Tests DecodeString method.
        /// </summary>
        /// <param name="expected">Expected decoding result.</param>
        /// <param name="input">Input string.</param>
        [Test]
        [TestCaseSource(nameof(GetDecodeTestData))]
        [TestCaseSource(nameof(GetEncodeDecodeTestData))]
        public void DecodeInputStringSuccess(string expected, string input) => _base64Service.DecodeString(input).Should().Be(expected);

        /// <summary>
        /// Tests DecodeString method with non-UTF-8 encoding results.
        /// </summary>
        /// <param name="input">Input string.</param>
        [Test]
        [TestCaseSource(nameof(GetDecodeNonUtf8TestCaseData))]
        public void DecodeInputStringNonUtf8NotNull(string input) => _base64Service.DecodeString(input).Should().NotBeNullOrWhiteSpace();

        private static IEnumerable<object[]> GetEncodeDecodeTestData()
        {
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { " ", "IA==" };
            yield return new object[] { "test", "dGVzdA==" };
            yield return new object[] { "тест", "0YLQtdGB0YI=" };
            yield return new object[] { "^&?.", "XiY/Lg==" };
            yield return new object[] { "ÀËÆØ×þʭʢ", "w4DDi8OGw5jDl8O+yq3Kog==" };
            yield return new object[] { "ΛΞζѼӁԪճꣷݭضץحף", "zpvOns620bzTgdSq1bPqo7fdrdi216XYrdej" };
        }

        private static IEnumerable<object[]> GetEncodeTestData()
        {
            yield return new object[] { null, string.Empty };
        }

        private static IEnumerable<object[]> GetDecodeTestData()
        {
            yield return new object[] { string.Empty, null };
            yield return new object[] { null, "a" };
            yield return new object[] { null, "abc" };
            yield return new object[] { null, "abcde" };
            yield return new object[] { null, "абвг" };
            yield return new object[] { null, "ÀËÆØ" };
            yield return new object[] { null, "-*==" };
        }

        private static IEnumerable<string> GetDecodeNonUtf8TestCaseData()
        {
            yield return "abcd";
            yield return "1234";
        }
    }
}
