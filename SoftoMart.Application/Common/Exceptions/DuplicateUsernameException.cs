using System;

namespace SoftoMart.Application.Common.Exceptions
{
  public class DuplicateUsernameException : Exception
  {
    public DuplicateUsernameException(string username) : base($"{username} is already taken")
    {
    }
  }
}
