using System.Text.RegularExpressions;

namespace SoftoMart.Domain.Common
{
  public class BaseEntity
  {
    public int Id { get; set; }


    protected bool _Match(string pattern, string value) => new Regex(pattern).IsMatch(value);
  }
}
