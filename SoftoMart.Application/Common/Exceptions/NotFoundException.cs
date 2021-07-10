using System;

namespace SoftoMart.Application.Common.Exceptions
{
  public class NotFoundException:Exception
  {
    public string Property { get; set; }
    public NotFoundException(string property):base($"{property} not found")
    {
      this.Property = property;
    }
  }
}
