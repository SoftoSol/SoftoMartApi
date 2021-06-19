using SoftoMart.Application.Common.Contracts;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Persistence
{
  public class SqlUnitOfWorkFactory : IUnitOfWorkFactory
  {
    const string ConnectionString = "server=.;database=softomart;Trusted_Connection=True;";
    public IUnitOfWork Create()
    {
      var connection = new SqlConnection(ConnectionString);
      connection.Open();
      return new SqlUnitOfWork(connection);
    }
  }
}
