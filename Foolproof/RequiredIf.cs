using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Foolproof
{
    public class RequiredIfAttribute : ContingentValidationAttribute
    {
        public Operator Operator { get; private set; }
        public object DependentValue { get; private set; }
        public string DependentValueDisplayName { get; private set; }

        protected OperatorMetadata Metadata { get; private set; }
        
        public RequiredIfAttribute(string dependentProperty, Operator @operator, object dependentValue)
            : base(dependentProperty)
        {
            Operator = @operator;
            DependentValue = dependentValue;
            Metadata = OperatorMetadata.Get(Operator);
            DependentValueDisplayName = GetDisplayName(dependentValue);
        }

        public RequiredIfAttribute(string dependentProperty, object dependentValue)
            : this(dependentProperty, Operator.EqualTo, dependentValue) { }

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(ErrorMessageResourceName) && string.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = DefaultErrorMessage;
            return string.Format(ErrorMessageString, name, DependentPropertyDisplayName ?? DependentProperty, DependentValueDisplayName ?? DependentValue);
        }

        public override string ClientTypeName
        {
            get { return "RequiredIf"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetClientValidationParameters()
        {
            return base.GetClientValidationParameters()
                .Union(new[] {
                    new KeyValuePair<string, object>("Operator", Operator.ToString()),
                    new KeyValuePair<string, object>("DependentValue", DependentValue)
                });
        }

        public override bool IsValid(object value, object dependentValue, object container)
        {
            if (Metadata.IsValid(dependentValue, DependentValue))
                return value != null && !string.IsNullOrEmpty(value.ToString().Trim());

            return true;
        }

        public override string DefaultErrorMessage
        {
            get { return "{0} is required due to {1} being " + Metadata.ErrorMessage + " {2}"; }
        }

        public string GetDisplayName(object value)
        {
            Type type = value.GetType();
            if (type.IsEnum)
            {
                var members = (from member in type.GetMembers()
                               from attribute in member.GetCustomAttributes(typeof(DisplayAttribute), true)
                               select member).ToList();

                if (members != null && members.Count >= 1)
                {
                    var member = members.FirstOrDefault(m => string.Equals(string.Format("{0}",m.Name),string.Format("{0}",value), StringComparison.InvariantCultureIgnoreCase));
                    if (member != null)
                    {
                        object[] attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                        if (attributes != null && attributes.Length >= 1)
                        {
                            return ((DisplayAttribute)attributes[0]).Name;
                        }
                    }
                }
            }
            return string.Format("{0}", value);
        }
    }
}
