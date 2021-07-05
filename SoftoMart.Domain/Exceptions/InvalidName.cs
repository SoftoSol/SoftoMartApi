using System;

namespace SoftoMart.Domain.Exceptions
{
  public class InvalidName:Exception
  {
    public InvalidName() { }
    public InvalidName(string name) : base($"Invalid name: {name}") { }
    public InvalidName(string message, string name) : base($"{message}\nName: {name}") { }
  }
}
