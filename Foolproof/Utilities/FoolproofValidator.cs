using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace Foolproof
{
    public class FoolproofValidator : DataAnnotationsModelValidator<ModelAwareValidationAttribute>
    {
        public FoolproofValidator(ModelMetadata metadata, ControllerContext context, ModelAwareValidationAttribute attribute)
            : base(metadata, context, attribute) { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (!Attribute.IsValid(Metadata.Model, container))
                yield return new ModelValidationResult { Message = ErrorMessage };                    
        }

    public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
    {
        if (Attribute is ContingentValidationAttribute)
        {
            ContingentValidationAttribute attribute = Attribute as ContingentValidationAttribute;

            PropertyInfo otherPropertyInfo = this.Metadata.ContainerType.GetProperty(attribute.DependentProperty);

            var displayName = GetMetaDataDisplayName(otherPropertyInfo);

            if (displayName != null)
            {
                attribute.DependentPropertyDisplayName = displayName;
            }
        }

        var result = new ModelClientValidationRule()
        {
            ValidationType = Attribute.ClientTypeName.ToLower(),
            ErrorMessage = ErrorMessage 
        };
            
        foreach (var validationParam in Attribute.ClientValidationParameters)
            result.ValidationParameters.Add(validationParam);
            
        yield return result;
    }

        private string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(DisplayAttribute), true);

            if (atts.Length == 0)
                return null;

            return (atts[0] as DisplayAttribute).GetName();
        }


        private string GetMetaDataDisplayName(PropertyInfo property)
        {
            var atts = property.DeclaringType.GetCustomAttributes(
                typeof(MetadataTypeAttribute), true);

            if (atts.Length == 0)
            {
                return GetAttributeDisplayName(property); 
            }

            var metaAttr = atts[0] as MetadataTypeAttribute;
            
            var metaProperty = metaAttr.MetadataClassType.GetProperty(property.Name);
            
            if (metaProperty == null)
                return null;

            return GetAttributeDisplayName(metaProperty);
        }

    }
}
