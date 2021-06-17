namespace SoftoMart.Domain.Common
{
  public class PersonBaseEntity:AuditableBaseEntity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Phone { get; set; }
    public string Username { get; set; }
  }
}
