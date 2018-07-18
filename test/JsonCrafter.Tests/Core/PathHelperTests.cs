using JsonCrafter.Core.Helpers;
using Xunit;

namespace JsonCrafter.Tests.Core
{
    public class PathHelperTests
    {
        [Theory]
        [InlineData("http://test.tester.com/{id}")]
        [InlineData("http://test.tester.com/{dsa}/{fds123}/{id}")]
        [InlineData("http://test.tester1.com/{0}/{1}/{2}")]
        [InlineData("/abba/bassen")]
        [InlineData("/abba/bassen/")]
        [InlineData("/abba")]
        [InlineData("abba")]
        public void PathHelperTests_IsValidTemplateUrl_ShouldReturnTrue(string input)
        {
            Assert.True(input.IsValidTemplateUrl());
        }

        [Theory]
        [InlineData("c:\\fdas\\gewghre")]
        [InlineData("http://test.tester.com/a b/{fds123}/{id}")]
        [InlineData("aa bb")]
        [InlineData("\\re")]
        public void PathHelperTests_IsValidTemplateUrl_ShouldReturnFalse(string input)
        {
            Assert.False(input.IsValidTemplateUrl());
        }
    }
}
