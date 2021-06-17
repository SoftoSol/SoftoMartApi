using SoftoMart.Domain.Common;

namespace SoftoMart.Domain.Entities
{
  public class User : PersonBaseEntity
  {
    public string Password { get; set; }
  }
}
