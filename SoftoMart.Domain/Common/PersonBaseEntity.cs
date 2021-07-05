using SoftoMart.Domain.Exceptions;


namespace SoftoMart.Domain.Common
{
  public class PersonBaseEntity : AuditableBaseEntity
  {
    private string _FirstName;
    private string _LastName;
    private string _UserName;
    private string _Phone;

    private const string USERNAMEREGEX = "([a-z]*[A-Z]*[0-9]*[_,.]*)*";// small, caps, (_, .) as special characters
    private const string NAMEREGEX = "([a-zA-Z ])*";// small, caps and space
    public string FirstName
    {
      get => _FirstName;
      set
      {
        if (!_Match(NAMEREGEX, value))
        { throw new InvalidName(value); }
        _FirstName = value;
      }
    }
    public string LastName
    {
      get => _LastName;
      set
      {
        if (!_Match(NAMEREGEX, value))
        { throw new InvalidName(value); }
        _LastName = value;
      }
    }
    public string FullName => $"{FirstName} {LastName}";
    public string Phone
    {
      get => _Phone;
      set { _Phone = value; }
    }
    public string Username
    {
      get => _UserName;
      set
      {
        if (value.Length < 8 || value.Length > 50)
          throw new InvalidUsername("Invalid username length. it must be greater than 8 and less than 50", value);
        if (!_Match(USERNAMEREGEX, value))
          throw new InvalidUsername("Invalid username. Username must be combination of small alphabets, capital alphabets, and special characters(_,.)", value);
        _UserName = value;
      }
    }

  }
}
