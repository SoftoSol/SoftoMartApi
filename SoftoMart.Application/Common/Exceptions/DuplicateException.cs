using System;

namespace SoftoMart.Application.Common.Exceptions
{
  public class DuplicateException : Exception
  {
    public DuplicateException(string name) : base(name + " cannot be duplicate"){}
  }
}
