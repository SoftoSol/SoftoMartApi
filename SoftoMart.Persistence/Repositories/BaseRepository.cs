using SoftoMart.Domain.Common;

using System.Data;
using System.Data.SqlClient;

namespace SoftoMart.Persistence.Repositories
{
  public class BaseRepository
  {
    private IDbConnection _Connection;
    private IDbTransaction _Transaction;
    public BaseRepository(IDbConnection connection, IDbTransaction transaction)
    {
      _Connection = connection;
      _Transaction = transaction;
    }
    public int Delete(AuditableBaseEntity entity, string procedure)
    {
      var cmd = _Connection.CreateCommand(_Transaction);
      cmd.CommandText = procedure;
      cmd.Parameters.Add(new SqlParameter("@pId", entity.Id));
      cmd.Parameters.Add(new SqlParameter("@pModifiedy", entity.LastModifiedBy));
      return cmd.ExecuteNonQuery();
    }
  }
}
