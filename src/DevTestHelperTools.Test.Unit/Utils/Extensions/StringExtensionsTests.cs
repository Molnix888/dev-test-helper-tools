using System.Collections.Generic;
using DevTestHelperTools.Utils.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace DevTestHelperTools.Test.Unit.Utils.Extensions
{
    /// <summary>
    /// Contains tests for string extension methods.
    /// </summary>
    [TestFixture]
    public class StringExtensionsTests
    {
        /// <summary>
        /// Tests ResolveInput extension method.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="expected">Expected result string.</param>
        [Test]
        [TestCaseSource(nameof(GetResolveInputData))]
        public void ResolveInputStringSuccess(string input, string expected) => input.ResolveInput().Should().Be(expected);

        private static IEnumerable<TestCaseData> GetResolveInputData()
        {
            string nullString = null;
            var emptyString = string.Empty;
            var stringValue = "test";

            yield return new TestCaseData(nullString, emptyString);
            yield return new TestCaseData(emptyString, emptyString);
            yield return new TestCaseData(stringValue, stringValue);
        }
    }
}
