
namespace Foolproof.Core
{
  public class LessThanOrEqualToAttribute : IsAttribute
  {
    public LessThanOrEqualToAttribute(string dependentProperty) : base(Operator.LessThanOrEqualTo, dependentProperty) { }
  }
}
