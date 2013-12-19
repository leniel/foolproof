var foolproof = function () { };
foolproof.is = function (value1, operator, value2, passOnNull) {
    if (passOnNull) {
        var isNullish = function (input) {
            return input == null || input == undefined || input == "";
        };

        var value1nullish = isNullish(value1);
        var value2nullish = isNullish(value2);

        if ((value1nullish && !value2nullish) || (value2nullish && !value1nullish))
            return true;
    }

    var isNumeric = function (input) {
        var number = Globalize.parseFloat(input);
        return !isNaN(number);
    };
    
    var isDate = function (input) {
        var date = Globalize.parseDate(input);
        if (date != null)
            return !isNaN(date.valueOf());
        else
            return false;
    };

    if (isDate(value1)) {
        value1 = Globalize.parseDate(value1);
        value2 = Globalize.parseDate(value2);
    }

    var isBool = function (input) {
        return input === true || input === false || input === "true" || input === "false";
    };

    if (isDate(value1)) {
        value1 = Date.parse(value1);
        value2 = Date.parse(value2);
    }
    else if (isBool(value1)) {
        if (value1 == "false") value1 = false;
        if (value2 == "false") value2 = false;
        value1 = !!value1;
        value2 = !!value2;
    }
    else if (isNumeric(value1)) {
        value1 = Globalize.parseFloat(value1);
        value2 = Globalize.parseFloat(value2);
    }

    switch (operator) {
        case "EqualTo": if (value1 == value2) return true; break;
        case "NotEqualTo": if (value1 != value2) return true; break;
        case "GreaterThan": if (value1 > value2) return true; break;
        case "LessThan": if (value1 < value2) return true; break;
        case "GreaterThanOrEqualTo": if (value1 >= value2) return true; break;
        case "LessThanOrEqualTo": if (value1 <= value2) return true; break;
        case "RegExMatch": return (new RegExp(value2)).test(value1); break;
        case "NotRegExMatch": return !(new RegExp(value2)).test(value1); break;
    }

    return false;
};

foolproof.getId = function (element, dependentPropety) {
    var pos = element.id.lastIndexOf("_") + 1;
    return element.id.substr(0, pos) + dependentPropety.replace(/\./g, "_");
};

foolproof.getName = function (element, dependentPropety) {
    var pos = element.name.lastIndexOf(".") + 1;
    return element.name.substr(0, pos) + dependentPropety;
};

Sys.Mvc.ValidatorRegistry.validators["is"] = function (rule) {
    return function (value, context) {
        var operator = rule.ValidationParameters["operator"];
        var passOnNull = rule.ValidationParameters["passonnull"];
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["dependentproperty"]);
        var dependentValue = document.getElementById(dependentProperty).value;

        if (foolproof.is(value, operator, dependentValue, passOnNull))
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["requiredif"] = function (rule) {
    var pattern = rule.ValidationParameters["pattern"];
    var dependentTestValue = rule.ValidationParameters["dependentvalue"];
    var operator = rule.ValidationParameters["operator"];
    return function (value, context) {
        var dependentProperty = foolproof.getName(context.fieldContext.elements[0], rule.ValidationParameters["dependentproperty"]);
        var dependentPropertyElement = document.getElementsByName(dependentProperty);
        var dependentValue = null;

        if (dependentPropertyElement.length > 1) {
            for (var index = 0; index != dependentPropertyElement.length; index++)
                if (dependentPropertyElement[index]["checked"]) {
                    dependentValue = dependentPropertyElement[index].value;
                    break;
                }

            if (dependentValue == null)
                dependentValue = false
        }
        else
            dependentValue = dependentPropertyElement[0].value;

        if (foolproof.is(dependentValue, operator, dependentTestValue)) {
            if (pattern == null) {
                if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                    return true;
            }
            else
                return (new RegExp(pattern)).test(value);
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["requiredifempty"] = function (rule) {
    return function (value, context) {
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["dependentproperty"]);
        var dependentValue = document.getElementById(dependentProperty).value;

        if (dependentValue == null || dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') == "") {
            if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                return true;
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};

Sys.Mvc.ValidatorRegistry.validators["requiredifnotempty"] = function (rule) {
    return function (value, context) {
        var dependentProperty = foolproof.getId(context.fieldContext.elements[0], rule.ValidationParameters["dependentproperty"]);
        var dependentValue = document.getElementById(dependentProperty).value;

        if (dependentValue != null && dependentValue.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "") {
            if (value != null && value.toString().replace(/^\s\s*/, '').replace(/\s\s*$/, '') != "")
                return true;
        }
        else
            return true;

        return rule.ErrorMessage;
    };
};