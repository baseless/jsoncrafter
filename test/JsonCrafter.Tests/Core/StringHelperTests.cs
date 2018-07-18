using Xunit;
using JsonCrafter.Core.Helpers;

namespace JsonCrafter.Tests.Core
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("jnui543543fGrewqp")]
        [InlineData("a")]
        [InlineData("3")]
        [InlineData("44432gfds")]
        [InlineData("GHD3")]
        public void StringHelperTests_IsPlainText_ShouldReturnTrue(string input)
        {
            Assert.True(input.IsPlainText());
        }

        [Theory]
        [InlineData("jnui543#543fGrew/qp")]
        [InlineData("a%")]
        [InlineData("3-")]
        [InlineData("444!32gfds")]
        [InlineData("G?H'D3")]
        [InlineData("åäö")]
        [InlineData("aa bb")]
        public void StringHelperTests_IsPlainText_ShouldReturnFalse(string input)
        {
            Assert.False(input.IsPlainText());
        }
    }
}
