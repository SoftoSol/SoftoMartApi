using System;

namespace SoftoMart.Application.Common.Contracts
{
  public interface ILogger
  {
    void Log(string message);
    void Log(Exception exception);
  }
}
