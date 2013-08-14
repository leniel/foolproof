
namespace Foolproof
{
    public class RequiredIfRegExMatchAttribute : RequiredIfAttribute
    {
        public RequiredIfRegExMatchAttribute(string dependentProperty, string pattern) : base(dependentProperty, Operator.RegExMatch, pattern) { }
    }
}
