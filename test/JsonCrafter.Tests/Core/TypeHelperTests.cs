using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using JsonCrafter.Core.Helpers;
using Xunit;

namespace JsonCrafter.Tests.Core
{
    public class TypeHelperTests
    {
        protected class TypeHelperTestsClass
        {
            public string TestProp { get; set; } = "abc";
            public int IntProp { get; set; } = 123;
            public string StringField = "abc";
            public int IntField = 123;
            public bool BoolProp { get; set; }

            protected string ProtStringProp { get; set; } = "few";
            private string PrivStringProp { get; set; } = "few";
            protected string ProtStringField { get; set; } = "few";
            private string PrivStringField { get; set; } = "few";

            public string SomeMethod() => string.Empty;

            public ICollection<string> ListOfStringsProp { get; set; } = new List<string>();
            public ICollection<string> ListOfStringsField = new List<string>();

            public int[] IntArrayProp { get; set; } = new[] { 1 };
            public int[] IntArrayField { get; set; } = new[] { 2 };
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(int))]
        [InlineData(typeof(short))]
        [InlineData(typeof(long))]
        [InlineData(typeof(ushort))]
        [InlineData(typeof(uint))]
        [InlineData(typeof(ulong))]
        [InlineData(typeof(byte))]
        [InlineData(typeof(bool))]
        [InlineData(typeof(sbyte))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(double))]
        [InlineData(typeof(float))]
        [InlineData(typeof(DateTime))]
        [InlineData(typeof(DateTimeOffset))]
        [InlineData(typeof(DateTimeKind))]
        public void TypeHelper_IsSimple_ShouldReturnTrue(Type type)
        {
            Assert.True(type.IsSimple());
        }

        [Theory]
        [InlineData(typeof(string[]))]
        [InlineData(typeof(List<string>))]
        [InlineData(typeof(Dictionary<string, string>))]
        [InlineData(typeof(bool[]))]
        [InlineData(typeof(TypeHelperTestsClass))]
        public void TypeHelper_IsSimple_ShouldReturnFalse(Type type)
        {
            Assert.False(type.IsSimple());
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(int))]
        [InlineData(typeof(short))]
        [InlineData(typeof(long))]
        [InlineData(typeof(ushort))]
        [InlineData(typeof(uint))]
        [InlineData(typeof(ulong))]
        [InlineData(typeof(byte))]
        [InlineData(typeof(bool))]
        [InlineData(typeof(sbyte))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(double))]
        [InlineData(typeof(float))]
        [InlineData(typeof(DateTime))]
        [InlineData(typeof(DateTimeOffset))]
        [InlineData(typeof(DateTimeKind))]
        [InlineData(typeof(TypeHelperTestsClass))]
        public void TypeHelper_IsAnyCollection_ShouldReturnFalse(Type type)
        {
            Assert.False(type.IsAnyCollection());
        }

        [Theory]
        [InlineData(typeof(string[]))]
        [InlineData(typeof(List<string>))]
        [InlineData(typeof(Dictionary<string, string>))]
        [InlineData(typeof(Lookup<string, string>))]
        [InlineData(typeof(Stack<string>))]
        [InlineData(typeof(HashSet<string>))]
        [InlineData(typeof(bool[]))]
        [InlineData(typeof(IEnumerable<string>))]
        [InlineData(typeof(ICollection<string>))]
        [InlineData(typeof(IDictionary<string, string>))]
        [InlineData(typeof(IImmutableList<string>))]
        [InlineData(typeof(IImmutableDictionary<string, string>))]
        [InlineData(typeof(IImmutableQueue<string>))]
        [InlineData(typeof(IImmutableSet<string>))]
        [InlineData(typeof(IImmutableStack<string>))]
        public void TypeHelper_IsAnyCollection_ShouldReturnTrue(Type type)
        {
            Assert.True(type.IsAnyCollection());
        }
    }
}
