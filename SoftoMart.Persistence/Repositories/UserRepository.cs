using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Common;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Persistence.Repositories
{
public class UserRepository :BaseRepository, IUserRepository
  {
    public IDbConnection Connection { get; private set; }
    private IDbTransaction _Transaction;

    public UserRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction) { Connection = connection; _Transaction = transaction; }

    public int Create(User entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.CreateUser;
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pUsername", entity.Username));
      cmd.Parameters.Add(new SqlParameter("@pPassword", entity.Password));
      cmd.Parameters.Add(new SqlParameter("@pCreatedBy", entity.CreatedBy));
      return cmd.ExecuteNonQuery();
    }
    public int Delete(User entity)
    {
      return base.Delete(entity, SqlProcedures.DeleteUser);
    }

    public User Get(int id)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetUser;
      cmd.Parameters.Add(new SqlParameter("@pId", id));
      using (var reader = cmd.ExecuteReader())
      {
        if (reader is null || reader.FieldCount is 0)
          return null;
          return UserUtils.MapUser(reader);
      }
    }

    public List<User> Get()
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetUsers;
      using (var reader=cmd.ExecuteReader())
      {
        if (reader is null||reader.FieldCount is 0) return null;
        var users = new List<User>();
        while (reader.Read())
        {
          users.Add(UserUtils.MapUser(reader));
        }
        return users;
      }
    }

    public int Update(User entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.UpdateUser;
      cmd.Parameters.Add(new SqlParameter("@pId", entity.Id));
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pUsername", entity.Username));
      cmd.Parameters.Add(new SqlParameter("@pPassword", entity.Password));
      cmd.Parameters.Add(new SqlParameter("@@pModifiedBy", entity.LastModifiedBy));
      return cmd.ExecuteNonQuery();
    }

    public User GetByUserName(string username)
    { 
      var command = Connection.CreateCommand(_Transaction);
      command.CommandText = SqlProcedures.GetUserByUsername;
      command.Parameters.Add(new SqlParameter("@pUsername", username));
        var reader = command.ExecuteReader();
        if (!reader.Read())
        {
          reader.Close();
          return null;
        }
      var user = UserUtils.MapUser(reader);
        reader.Close();
      return user;
    }
  }

  internal class UserUtils
  {
    internal static User MapUser(IDataReader reader)
    {
      if (reader.Read())
      {
        return new User()
        {
          Id = Convert.ToInt32(reader["Id"]),
          FirstName = reader["FirstName"].ToString(),
          LastName = reader["LastName"].ToString(),
          Phone = reader["Phone"].ToString(),
          Username = reader["Username"].ToString(),
          CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
          CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString()),
          LastModifiedBy = Convert.ToInt32(reader["LastModifiedBy"].ToString()),
          LastModifiedAt = Convert.ToDateTime(reader["LastModifiedAt"].ToString())
        };
      }
      return null;
    }
  }
}
