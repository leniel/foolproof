# foolproof

MVC Foolproof Validation aims to extend the Data Annotation validation provided in ASP.NET MVC.

## Install

via NuGet:

```powershell
install-package foolproof
```

MVC Foolproof Validation aims to extend the Data Annotation validation provided in ASP.NET MVC. Initial efforts are focused on adding contingent validation.

## Setup

Note: To build the source code, you will need to have the Microsoft AJAX Minifier installed: http://aspnet.codeplex.com/releases/view/40584

## Operator Validation

```c#
public class SignUpViewModel
{
    [Required]
    public string Password { get; set; }

    [EqualTo("Password", ErrorMessage="Passwords do not match.")]
    public string RetypePassword { get; set; }
}
public class EventViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime Start { get; set; }

    [Required]
    [GreaterThan("Start")]
    public DateTime End { get; set; }
}
```

## Included Operator Validators

```c#
[Is]
[EqualTo]
[NotEqualTo]
[GreaterThan]
[LessThan]
[GreaterThanOrEqualTo]
[LessThanOrEqualTo]
```

## Required Validation

```c#
private class Person
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public bool Married { get; set; }

    [RequiredIfTrue("Married")]
    public string MaidenName { get; set; }
}
```

## Included Required Validators

```c#
[RequiredIf]
[RequiredIfNot]
[RequiredIfTrue]
[RequiredIfFalse]
[RequiredIfEmpty]
[RequiredIfNotEmpty]
[RequiredIfRegExMatch]
[RequiredIfNotRegExMatch]
```

## Client Validation

To enable client validation, include MvcFoolproofValidation.js with the standard client validation script files:

```html
<script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
<script src="../../Scripts/MvcFoolproofValidation.js" type="text/javascript"></script>
```

## jQuery Validation

If you are using jQuery validation, include MvcFoolproofJQueryValidation.js with the standard client validation script files:

```html
<script src="../../Scripts/jquery.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-validate.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>
<script src="../../Scripts/MvcFoolproofJQueryValidation.js" type="text/javascript"></script>
```

## MVC 3 jQuery Unobtrusive Support

```html
<script src="@Url.Content("~/Scripts/jquery.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/mvcfoolproof.unobtrusive.js")" type="text/javascript"></script>
```

## Complex Custom Validation

### Custom Validation Attribute:

```c#
public class RoleValidInDepartmentAttribute : ModelAwareValidationAttribute
{
    //this is needed to register this attribute with foolproof's validator adapter
    static RoleValidInDepartmentAttribute() { Register.Attribute(typeof(RoleValidInDepartmentAttribute)); }

    public override bool IsValid(object value, object container)
    {
        if (value != null && value.ToString() == "Software Developers")
        {
            //if the role was software developers, we need to make sure the user is in the IT department
            var model = (CreateUserViewModel)container;
            return model.Department == "IT Department";
        }

        //the user wasn't in a constrained role, so just return true
        return true;
    }
}
```

### Applied to a Model

```c#
public class CreateUserViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Department { get; set; }

    [Required]
    [RoleValidInDepartment(ErrorMessage="This role isn't valid for the selected department.")]
    public string Role { get; set; }
}
```

[More information on building a custom validation attribute](http://nickriggs.com/posts/build-model-aware-custom-validation-attributes-in-asp-net-mvc-2/)