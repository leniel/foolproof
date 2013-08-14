using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foolproof.UnitTests.JavaScript.Models
{
    public class IsWithPassOnNull
    {
        public class EqualToStrings
        {
            public string Value1 { get; set; }

            [EqualTo("Value1", PassOnNull = true)]
            public string Value2 { get; set; }
        }

        //public class NotEqualToStrings
        //{
        //    public string Value1 { get; set; }

        //    [NotEqualTo("Value1")]
        //    public string Value2 { get; set; }
        //}

        //public class GreaterThanDates
        //{
        //    public DateTime Value1 { get; set; }

        //    [GreaterThan("Value1")]
        //    public DateTime Value2 { get; set; }
        //}

        //public class GreaterThanDecimal
        //{
        //    public Decimal Value1 { get; set; }

        //    [GreaterThan("Value1")]
        //    public Decimal Value2 { get; set; }
        //}

        //public class GreaterThanInt
        //{
        //    public int Value1 { get; set; }

        //    [GreaterThan("Value1")]
        //    public int Value2 { get; set; }
        //}

        //public class LessThanInt
        //{
        //    public int Value1 { get; set; }

        //    [LessThan("Value1")]
        //    public int Value2 { get; set; }
        //}

        public EqualToStrings EqualToStringsValid { get; set; }
        //public EqualToStrings EqualToStringsInvalid { get; set; }
        //public NotEqualToStrings NotEqualToStringsValid { get; set; }
        //public NotEqualToStrings NotEqualToStringsInvalid { get; set; }
        //public GreaterThanDates GreaterThanDatesValid { get; set; }
        //public GreaterThanDates GreaterThanDatesInvalid { get; set; }
        //public GreaterThanDecimal GreaterThanDecimalValid { get; set; }
        //public GreaterThanInt GreaterThanIntValid { get; set; }
        //public LessThanInt LessThanIntValid { get; set; }

        public IsWithPassOnNull()
        {
            EqualToStringsValid = new EqualToStrings() { Value1 = null, Value2 = "hello" };
            //EqualToStringsInvalid = new EqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            //NotEqualToStringsValid = new NotEqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            //NotEqualToStringsInvalid = new NotEqualToStrings() { Value1 = "hello", Value2 = "hello" };
            //GreaterThanDatesValid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(-1), Value2 = DateTime.Now };
            //GreaterThanDatesInvalid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(1), Value2 = DateTime.Now };
            //GreaterThanDecimalValid = new GreaterThanDecimal() {Value1 = 5, Value2 = 10};
            //GreaterThanIntValid = new GreaterThanInt() {Value1 = 5, Value2 = 10};
            //LessThanIntValid = new LessThanInt() {Value1 = 10, Value2 = 5};
        }
    }

    public partial class Model
    {
        public IsWithPassOnNull IsPassOnNullTests = new IsWithPassOnNull();
    }
}