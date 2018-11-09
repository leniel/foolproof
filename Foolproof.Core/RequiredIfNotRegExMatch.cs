
namespace Foolproof.Core
{
  public class RequiredIfNotRegExMatchAttribute : RequiredIfAttribute
  {
    public RequiredIfNotRegExMatchAttribute(string dependentValue, string pattern) : base(dependentValue, Operator.NotRegExMatch, pattern) { }
  }
}
