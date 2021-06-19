using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Persistence.Repositories;

using System;
using System.Data;
using System.Data.SqlClient;

namespace SoftoMart.Persistence
{
  public class SqlUnitOfWork : IUnitOfWork
  {
    #region REPOSITORIES
    IUserRepository _UserRepository;


    public IUserRepository UserRepository => _UserRepository ??= new UserRepository(Connection, Transaction);
    #endregion
    public IDbConnection Connection { get; private set; }
    private IDbTransaction Transaction;
    public void Commit()
    {
      _ = Transaction ?? throw new Exception("null exception");
      Transaction.Commit();
    }

    public SqlUnitOfWork(SqlConnection connection)
    {
      Connection = connection;
      Transaction = Connection.BeginTransaction();
    }

    public void Dispose()
    {
      //Transaction?.Rollback();
      Connection?.Close();
      Transaction = null;
      Connection = null;
    }

    public void Rollback()
    {
      Transaction?.Rollback();
    }
  }
}
