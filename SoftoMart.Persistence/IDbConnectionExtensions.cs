using System.Data;

namespace SoftoMart.Persistence
{
  public static class IDbConnectionExtensions
  {
    public static IDbCommand CreateCommand(this IDbConnection connection, IDbTransaction transaction)
    {
      var command = connection.CreateCommand();
      command.Transaction = transaction;
      command.CommandType = CommandType.StoredProcedure;
      return command;
    }
  }
}
