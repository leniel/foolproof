
namespace Foolproof
{
    public class GreaterThanOrEqualToAttribute : IsAttribute
    {
        public GreaterThanOrEqualToAttribute(string dependentProperty) : base(Operator.GreaterThanOrEqualTo, dependentProperty) { }
    }
}
