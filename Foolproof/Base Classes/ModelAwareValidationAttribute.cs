using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Foolproof
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ModelAwareValidationAttribute : ValidationAttribute
    {
        public ModelAwareValidationAttribute() { }
        
        static ModelAwareValidationAttribute()
        {
            Register.All();            
        }    

        public override bool IsValid(object value)
        {
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(ErrorMessageResourceName) && string.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = DefaultErrorMessage;
            
            return base.FormatErrorMessage(name);
        }

        public virtual string DefaultErrorMessage
        {
            get { return "{0} is invalid."; }
        }

        public abstract bool IsValid(object value, object container);

        public virtual string ClientTypeName
        {
            get { return this.GetType().Name.Replace("Attribute", ""); }
        }

        protected virtual IEnumerable<KeyValuePair<string, object>> GetClientValidationParameters()
        {
            return new KeyValuePair<string, object>[0];
        }
        
        public Dictionary<string, object> ClientValidationParameters
        {
            get { return GetClientValidationParameters().ToDictionary(kv => kv.Key.ToLower(), kv => kv.Value); }
        }
    }
}
