<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Foolproof.UnitTests.JavaScript.Models.Model>" %>
<%@ Import Namespace="Foolproof.UnitTests.JavaScript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        Sys.Application.add_load(function () {
            $("form").get(0)[Sys.Mvc.FormContext._formValidationTag].validate("submit");

            module("Is");

            test("EqualTo Strings", function () {
                ok($("#IsTests_EqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Invalid Test");
                ok(!$("#IsTests_EqualToStringsValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("EqualTo Strings Complex", function () {
                ok(!$("#IsTests_EqualToStringsComplexValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("NotEqualTo Strings", function () {
                ok($("#IsTests_NotEqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Invalid Test");
                ok(!$("#IsTests_NotEqualToStringsValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("GreaterThan Dates", function () {
                ok(!$("#IsTests_GreaterThanDates_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("GreaterThan Decimals", function () {
                ok(!$("#IsTests_GreaterThanDecimals_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("GreaterThan Integers", function () {
                ok(!$("#IsTests_GreaterThanInts_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("LessThan Integers", function () {
                ok(!$("#IsTests_LessThanInts_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            module("IsWithPassNull");

            test("EqualTo (PassOnNull) Strings", function () {
                ok(!$("#IsPassOnNullTests_EqualToStringsValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });            
            
            module("Required If");

            test("EqualTo True", function () {
                ok(!$("#RequiredTests_EqualToTrue_IsTrueHasValue_Value2").hasClass("input-validation-error"), "True, Valid Test");
                ok($("#RequiredTests_EqualToTrue_IsTrueNoValue_Value2").hasClass("input-validation-error"), "True, Invalid Test");
                ok(!$("#RequiredTests_EqualToTrue_IsFalseNoValue_Value2").hasClass("input-validation-error"), "False, Valid Test");
            });

            test("EqualTo False", function () {
                ok(!$("#RequiredTests_EqualToFalse_IsFalseHasValue_Value2").hasClass("input-validation-error"), "False, Valid Test");
                ok($("#RequiredTests_EqualToFalse_IsFalseNoValue_Value2").hasClass("input-validation-error"), "False, Invalid Test");
                ok(!$("#RequiredTests_EqualToFalse_IsTrueNoValue_Value2").hasClass("input-validation-error"), "True, Valid Test");
            });
        });                    
    </script>
    <h1 id="qunit-header">
        QUnit example</h1>
    <h2 id="qunit-banner">
    </h2>
    <h2 id="qunit-userAgent">
    </h2>
    <ol id="qunit-tests">
    </ol>
    <div style="display: none;">
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsInvalid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsComplexValid.Value1.Value)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsComplexValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsComplexValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsInvalid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDatesValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDatesValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.GreaterThanDatesValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDecimalValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDecimalValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.GreaterThanDecimalValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanIntValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanIntValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.GreaterThanIntValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.LessThanIntValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.LessThanIntValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.LessThanIntValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsPassOnNullTests.EqualToStringsValid.Value1)%>
            <%= Html.EditorFor(m => m.IsPassOnNullTests.EqualToStringsValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsPassOnNullTests.EqualToStringsValid.Value2)%>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToTrue_IsTrueHasValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToTrue_IsTrueHasValue.Value2)%>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToTrue_IsTrueHasValue.Value2)%>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToTrue_IsTrueNoValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToTrue_IsTrueNoValue.Value2)%>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToTrue_IsTrueNoValue.Value2)%>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToTrue_IsFalseNoValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToTrue_IsFalseNoValue.Value2)%>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToTrue_IsFalseNoValue.Value2)%>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToFalse_IsFalseHasValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToFalse_IsFalseHasValue.Value2) %>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToFalse_IsFalseHasValue.Value2) %>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToFalse_IsFalseNoValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToFalse_IsFalseNoValue.Value2)%>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToFalse_IsFalseNoValue.Value2)%>
        </div>
        <div>
            <%= Html.CheckBoxFor(m => m.RequiredTests.EqualToFalse_IsTrueNoValue.Value1) %>
            <%= Html.EditorFor(m => m.RequiredTests.EqualToFalse_IsTrueNoValue.Value2)%>
            <%= Html.ValidationMessageFor(m => m.RequiredTests.EqualToFalse_IsTrueNoValue.Value2)%>
        </div>
        <% } %>
    </div>
</asp:Content>
