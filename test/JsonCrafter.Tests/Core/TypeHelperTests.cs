using System;
using System.Collections.Generic;
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

            public int[] IntArrayProp { get; set; }  = new[] { 1 };
            public int[] IntArrayField { get; set; } = new[] { 2 };
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(int))]
        [InlineData(typeof(Int16))]
        [InlineData(typeof(Int64))]
        [InlineData(typeof(UInt16))]
        [InlineData(typeof(UInt32))]
        [InlineData(typeof(UInt64))]
        [InlineData(typeof(byte))]
        [InlineData(typeof(bool))]
        [InlineData(typeof(sbyte))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(Double))]
        [InlineData(typeof(Single))]
        public void TypeHelper_IsStringOrValue_ShouldReturnTrue(Type type)
        {
            Assert.True(type.IsStringOrValue());
        }

        [Theory]
        [InlineData(typeof(string[]))]
        [InlineData(typeof(List<string>))]
        [InlineData(typeof(Dictionary<string, string>))]
        [InlineData(typeof(bool[]))]
        [InlineData(typeof(TypeHelperTestsClass))]
        public void TypeHelper_IsStringOrValue_ShouldReturnFalse(Type type)
        {
            Assert.False(type.IsStringOrValue());
        }

        //[Fact]
        //public void TypeHelper_GetMemberSummary_ShouldReturnPropertyInfo()
        //{
        //}

        //[Fact]
        //public void TypeHelper_GetMemberSummary_ShouldReturnFieldInfo()
        //{

        //}

        //[Theory]
        //public void TypeHelper_GetMemberSummary_ShouldReturnNull()
        //{

        //}

        //[Theory]
        //public void TypeHelper_GetMembers_ShouldReturnMembers()
        //{

        //}


        //[Theory]
        //public void TypeHelper_IsDecimal_ShouldReturnTrue()
        //{

        //}


        //[Theory]
        //public void TypeHelper_IsDecimal_ShouldReturnFalse()
        //{

        //}

        //[Theory]
        //public void TypeHelper_IsDecimal_ShouldReturnTrue()
        //{

        //}


        //[Theory]
        //public void TypeHelper_IsNumeric_ShouldReturnTru()
        //{

        //}

        //[Theory]
        //public void TypeHelper_IsNumeric_ShouldReturnFalse()
        //{

        //}
    }
}
