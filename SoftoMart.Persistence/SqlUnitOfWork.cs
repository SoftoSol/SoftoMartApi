using SoftoMart.Application.Common.Contracts;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Persistence
{
  public class SqlUnitOfWork : IUnitOfWork
  {
    private string _DbString = "server=.;database=softomart;Trusted_Connection=True;";
    public IDbConnection  Connection { get; private set; }
    public IDbTransaction Transaction { get; private set; }
    public void Commit()
    {
      _ = Transaction ?? throw new Exception("null exception");
      Transaction.Commit();
    }

    public SqlUnitOfWork()
    {
      Connection = new SqlConnection(_DbString);
      Connection.Open();
      Transaction = Connection.BeginTransaction();
    }

    public void Dispose()
    {
      Transaction?.Rollback();
      Connection?.Close();
      Transaction = null;
      Connection = null;
    }
  }
}
