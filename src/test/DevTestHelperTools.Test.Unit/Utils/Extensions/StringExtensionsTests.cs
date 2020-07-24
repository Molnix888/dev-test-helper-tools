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

        private static IEnumerable<object[]> GetResolveInputData()
        {
            var testValue = "test";

            yield return new object[] { null, string.Empty };
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { testValue, testValue };
        }
    }
}
