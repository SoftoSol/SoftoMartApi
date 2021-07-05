using System;

namespace SoftoMart.Domain.Exceptions
{
  public class InvalidUsername : Exception
  {
    public InvalidUsername() { }
    public InvalidUsername(string username):base ($"Invalid username: {username}"){ }
    public InvalidUsername(string message, string username):base ($"{message} \nusername: {username}"){ }
  }
}
