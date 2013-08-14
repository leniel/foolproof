using System;
using System.Web.Mvc;

namespace Foolproof
{
    public static class Register
    {
        public static void Attribute(Type foolprooftAttributeType)
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(foolprooftAttributeType, typeof(FoolproofValidator));
        }

        internal static void All()
        {
            Attribute(typeof(IsAttribute));
            Attribute(typeof(EqualToAttribute));
            Attribute(typeof(NotEqualToAttribute));
            Attribute(typeof(GreaterThanAttribute));
            Attribute(typeof(LessThanAttribute));
            Attribute(typeof(GreaterThanOrEqualToAttribute));
            Attribute(typeof(LessThanOrEqualToAttribute));
            Attribute(typeof(RequiredIfAttribute));
            Attribute(typeof(RequiredIfTrueAttribute));
            Attribute(typeof(RequiredIfFalseAttribute));
            Attribute(typeof(RequiredIfEmptyAttribute));
            Attribute(typeof(RequiredIfNotEmptyAttribute));
            Attribute(typeof(RequiredIfNotAttribute));
            Attribute(typeof(RegularExpressionIfAttribute));
            Attribute(typeof(RequiredIfRegExMatchAttribute));
            Attribute(typeof(RequiredIfNotRegExMatchAttribute));    
        }
    }
}
