
namespace Foolproof.Core
{
  public class EqualToAttribute : IsAttribute
  {
    public EqualToAttribute(string dependentProperty) : base(Operator.EqualTo, dependentProperty) { }
  }
}
