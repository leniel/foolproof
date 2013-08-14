using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foolproof.UnitTests.JavaScript.Models
{
    public class EqualToTests
    {
        public class EqualToStrings
        {
            public string Value1 { get; set; }

            [EqualTo("Value1")]
            public string Value2 { get; set; }
        }

        public class EqualToDates
        {
            public DateTime? Value1 { get; set; }

            [EqualTo("Value1")]
            public DateTime? Value2 { get; set; }
        }

        public class EqualToIntegers
        {
            public int? Value1 { get; set; }

            [EqualTo("Value1")]
            public int? Value2 { get; set; }
        }

        public EqualToStrings EqualToStringsValid { get; set; }
        public EqualToStrings EqualToStringsNotValid { get; set; }

        public EqualToTests()
        {
            EqualToStringsValid = new EqualToStrings() { Value1 = "hello", Value2 = "hello" };
            EqualToStringsNotValid = new EqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
        }
    }

    public partial class Model
    {
        public EqualToTests EqualToTests = new EqualToTests();
    }
}