using System.Collections.Generic;
using System.Reflection;
using JsonCrafter.Core.Info;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JsonCrafter.Tests.Processing.Contracts
{
    public class MemberContractTests
    {
        protected class MemberContractTestsClass
        {
            public int Id { get; set; }
            public string Baba { get; set; }
            public bool Bolle { get; set; }
        }

        [Fact]
        public void PropertyContract_ShouldParseProperty()
        {
            var obj = new MemberContractTestsClass() { Id = 2001 };
            var contract = new MemberContract("self", "http://baba.com/props/{prp}", new []
            {
                new KeyValuePair<string, IValueInfo>("prp", new PropertyValueInfo(typeof(MemberContractTestsClass).GetProperty(nameof(MemberContractTestsClass.Id)))),
            });

            var token = contract.GetToken(obj);

            Assert.NotNull(token);
            Assert.True(token.Type.Equals(JTokenType.Property));
            Assert.Equal("\"self\": \"http://baba.com/props/2001\"", token.ToString());
        }

        [Fact]
        public void PropertyContract_ShouldParseProperties()
        {
            var obj = new MemberContractTestsClass() { Id = 2001, Baba = "obob", Bolle = true };
            var contract = new MemberContract("self", "http://baba.com/props/{prp}/granlund/{baba}/gg/{olof}/", new[]
            {
                new KeyValuePair<string, IValueInfo>("prp", new PropertyValueInfo(typeof(MemberContractTestsClass).GetProperty(nameof(MemberContractTestsClass.Id)))),
                new KeyValuePair<string, IValueInfo>("olof", new PropertyValueInfo(typeof(MemberContractTestsClass).GetProperty(nameof(MemberContractTestsClass.Bolle)))),
                new KeyValuePair<string, IValueInfo>("baba", new PropertyValueInfo(typeof(MemberContractTestsClass).GetProperty(nameof(MemberContractTestsClass.Baba))))
            });

            var token = contract.GetToken(obj);

            Assert.NotNull(token);
            Assert.True(token.Type.Equals(JTokenType.Property));
            Assert.Equal("\"self\": \"http://baba.com/props/2001/granlund/obob/gg/True/\"", token.ToString());
        }

        [Fact]
        public void PropertyContract_ShouldReturnUnchangedIfZeroProperties()
        {
            var idPropInfo = new PropertyValueInfo(typeof(MemberContractTestsClass).GetProperty(nameof(MemberContractTestsClass.Id)));
            var obj = new MemberContractTestsClass() { Id = 2001 };
            var contract = new MemberContract("self", "http://baba.com/props/sven/{ds}", new KeyValuePair<string, IValueInfo>[0]);

            var token = contract.GetToken(obj);

            Assert.NotNull(token);
            Assert.True(token.Type.Equals(JTokenType.Property));
            Assert.Equal("\"self\": \"http://baba.com/props/sven/{ds}\"", token.ToString());
        }

    }
}
