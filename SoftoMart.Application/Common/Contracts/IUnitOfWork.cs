using SoftoMart.Application.Common.Contracts.Repositories;

using System;
using System.Data;

namespace SoftoMart.Application.Common.Contracts
{
  public interface IUnitOfWork :IDisposable
  {
    #region REPOSITORIES

    IUserRepository UserRepository { get; }
    ISellerRepository SellerRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    #endregion
    IDbConnection Connection { get; }
    void Commit();
    void Rollback();
  }
}
