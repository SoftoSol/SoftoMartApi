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

  public class UserRepository : IUserRepository
  {
    public IDbConnection Connection { get; private set; }
    private IDbTransaction _Transaction;

    public UserRepository(IDbConnection connection, IDbTransaction transaction) { Connection = connection; _Transaction = transaction; }

    public int Create(User entity)
    {
      var cmd = Connection.CreateCommand();
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandText = SqlProcedures.CreateUser;
      cmd.Transaction = _Transaction;
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
      throw new NotImplementedException();
    }

    public User Get(int id)
    {
      throw new NotImplementedException();
    }

    public List<User> Get()
    {
      throw new NotImplementedException();
    }

    public int Update(User entity)
    {
      throw new NotImplementedException();
    }

    public User GetByUsername(string username)
    { 
      var command = Connection.CreateCommand();
      command.CommandType = CommandType.StoredProcedure;
      command.CommandText = SqlProcedures.GetUserByUsername;
      command.Parameters.Add(new SqlParameter("@pUsername", username));
      var reader = command.ExecuteReader();
      if (!reader.Read())
        return null;
      var user = new User()
      {
        Id = Convert.ToInt32(reader["Id"]),
        FirstName = reader["FirstName"].ToString(),
        LastName = reader["LastName"].ToString(),
        Phone = reader["Phone"].ToString(),
        Username = reader["Username"].ToString(),
      };
      reader.Close();
      return user;
    }
  }
}
