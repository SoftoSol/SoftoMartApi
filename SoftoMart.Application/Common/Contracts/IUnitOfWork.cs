using System;
using System.Data;

namespace SoftoMart.Application.Common.Contracts
{
  public interface IUnitOfWork :IDisposable
  {
    IDbConnection Connection { get; }
    void Commit();
  }
}
