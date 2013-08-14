using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests.JavaScript.Models
{
    public class RequiredTests
    {
        public class EqualToTrue
        {
            [Required]
            public bool Value1 { get; set; }

            [RequiredIf("Value1", Operator.EqualTo, true)]
            public string Value2 { get; set; }
        }

        public class EqualToFalse
        {
            [Required]
            public bool Value1 { get; set; }

            [RequiredIf("Value1", Operator.EqualTo, false)]
            public string Value2 { get; set; }
        }

        public EqualToTrue EqualToTrue_IsTrueHasValue { get; set; }
        public EqualToTrue EqualToTrue_IsTrueNoValue { get; set; }
        public EqualToTrue EqualToTrue_IsFalseNoValue { get; set; }

        public EqualToFalse EqualToFalse_IsFalseHasValue { get; set; }
        public EqualToFalse EqualToFalse_IsFalseNoValue { get; set; }
        public EqualToFalse EqualToFalse_IsTrueNoValue { get; set; }

        public RequiredTests()
        {
            EqualToTrue_IsTrueHasValue = new EqualToTrue() { Value1 = true, Value2 = "hello" };
            EqualToTrue_IsTrueNoValue = new EqualToTrue() { Value1 = true, Value2 = "" };
            EqualToTrue_IsFalseNoValue = new EqualToTrue() { Value1 = false, Value2 = "" };
            
            EqualToFalse_IsFalseHasValue = new EqualToFalse() { Value1 = false, Value2 = "hello" };
            EqualToFalse_IsFalseNoValue = new EqualToFalse() { Value1 = false, Value2 = "" };
            EqualToFalse_IsTrueNoValue = new EqualToFalse() { Value1 = true, Value2 = "" };
        }
    }

    public partial class Model
    {
        public RequiredTests RequiredTests = new RequiredTests();
    }
}