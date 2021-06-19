using SoftoMart.Application.Common.Contracts.Repositories;

using System;
using System.Data;

namespace SoftoMart.Application.Common.Contracts
{
  public interface IUnitOfWork :IDisposable
  {
    IUserRepository UserRepository { get; }
    IDbConnection Connection { get; }
    void Commit();
    void Rollback();
  }
}
