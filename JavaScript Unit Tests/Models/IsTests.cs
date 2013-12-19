﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foolproof.UnitTests.JavaScript.Models
{    
    public class IsTests
    {
        public class EqualToStrings
        {
            public string Value1 { get; set; }

            [EqualTo("Value1")]
            public string Value2 { get; set; }
        }

        public class EqualToStringsComplex
        {
            public class SubModel
            {
                public string Value { get; set; }
            }

            public SubModel Value1 { get; set; }

            [EqualTo("Value1.Value")]
            public string Value2 { get; set; }
        }

        public class NotEqualToStrings
        {
            public string Value1 { get; set; }

            [NotEqualTo("Value1")]
            public string Value2 { get; set; }
        }

        public class GreaterThanDates
        {
            public DateTime Value1 { get; set; }

            [GreaterThan("Value1")]
            public DateTime Value2 { get; set; }
        }

        public class GreaterThanDecimal
        {
            public Decimal Value1 { get; set; }

            [GreaterThan("Value1")]
            public Decimal Value2 { get; set; }
        }

        public class GreaterThanInt
        {
            public int Value1 { get; set; }

            [GreaterThan("Value1")]
            public int Value2 { get; set; }
        }

        public class LessThanInt
        {
            public int Value1 { get; set; }

            [LessThan("Value1")]
            public int Value2 { get; set; }
        }

        public EqualToStrings EqualToStringsValid { get; set; }
        public EqualToStrings EqualToStringsInvalid { get; set; }
        public EqualToStringsComplex EqualToStringsComplexValid { get; set; }
        public NotEqualToStrings NotEqualToStringsValid { get; set; }
        public NotEqualToStrings NotEqualToStringsInvalid { get; set; }
        public GreaterThanDates GreaterThanDatesValid { get; set; }
        public GreaterThanDates GreaterThanDatesInvalid { get; set; }
        public GreaterThanDecimal GreaterThanDecimalValid { get; set; }
        public GreaterThanInt GreaterThanIntValid { get; set; }
        public LessThanInt LessThanIntValid { get; set; }

        public IsTests()
        {
            EqualToStringsValid = new EqualToStrings() { Value1 = "hello", Value2 = "hello" };
            EqualToStringsInvalid = new EqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            EqualToStringsComplexValid = new EqualToStringsComplex() { Value1 = new EqualToStringsComplex.SubModel() { Value = "hello"}, Value2 = "hello"};
            NotEqualToStringsValid = new NotEqualToStrings() { Value1 = "hello", Value2 = "goodbye" };
            NotEqualToStringsInvalid = new NotEqualToStrings() { Value1 = "hello", Value2 = "hello" };
            GreaterThanDatesValid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(-1), Value2 = DateTime.Now };
            GreaterThanDatesInvalid = new GreaterThanDates() { Value1 = DateTime.Now.AddDays(1), Value2 = DateTime.Now };
            GreaterThanDecimalValid = new GreaterThanDecimal() {Value1 = 5.5m, Value2 = 10.6m};
            GreaterThanIntValid = new GreaterThanInt() {Value1 = 5, Value2 = 10};
            LessThanIntValid = new LessThanInt() {Value1 = 10, Value2 = 5};
        }
    }

    public partial class Model
    {
        public IsTests IsTests = new IsTests();
    }
}