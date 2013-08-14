
namespace Foolproof
{
    public class LessThanAttribute : IsAttribute
    {
        public LessThanAttribute(string dependentProperty) : base(Operator.LessThan, dependentProperty) { }
    }
}
