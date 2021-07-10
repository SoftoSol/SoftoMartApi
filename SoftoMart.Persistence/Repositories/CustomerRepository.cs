using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Common;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SoftoMart.Persistence.Repositories
{
  public class CustomerRepository : BaseRepository,ICustomerRepository
  {
    public IDbConnection Connection { get; private set; }
    private IDbTransaction _Transaction { get; set; }
    public CustomerRepository(IDbConnection connection, IDbTransaction transaction):base(connection, transaction)
    {
      Connection = connection;
      _Transaction = transaction;
    }

    public int Create(Customer entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.CreateCustomer;
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pUsername", entity.Username));
      cmd.Parameters.Add(new SqlParameter("@pCreatedBy", entity.CreatedBy));
      return cmd.ExecuteNonQuery();
    }

    public int Delete(Customer entity)
    {
      return base.Delete(entity, SqlProcedures.DeleteCustomer);
     }

    public Customer Get(int id)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetCustomer;
      cmd.Parameters.Add(new SqlParameter("@pId", id));
      using (var reader = cmd.ExecuteReader())
      {
        if (reader is null || reader.FieldCount is 0)
          return null;
        return CustomerUtils.MapCustomer(reader);
      }
    }

    public List<Customer> Get()
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetCustomers;
      using (var reader = cmd.ExecuteReader())
      {
        if (reader is null || reader.FieldCount is 0)
          return null;
        var users = new List<Customer>();
        while (reader.Read())
        {
          users.Add(CustomerUtils.MapCustomer(reader));
        }
        return users;
      }
    }

    public int Update(Customer entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.UpdateCustomer;
      cmd.Parameters.Add(new SqlParameter("@pId", entity.Id));
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pModifiedBy", entity.LastModifiedBy));
      return cmd.ExecuteNonQuery();
    }

    public Customer GetByUserName(string username)
    {
      var command = Connection.CreateCommand(_Transaction);
      command.CommandText = SqlProcedures.GetCustomerByUsername;
      command.Parameters.Add(new SqlParameter("@pUsername", username));
      using (var reader = command.ExecuteReader())
      {
        return CustomerUtils.MapCustomer(reader);
      }
    }
  }
  public static class CustomerUtils
  {
    public static Customer MapCustomer(IDataReader reader)
    {
      if (reader.Read())
      {
        return new Customer {
          Id = Convert.ToInt32(reader["Id"]),
          FirstName = reader["FirstName"].ToString(),
          LastName = reader["LastName"].ToString(),
          Phone = reader["Phone"].ToString(),
          Username = reader["Username"].ToString(),
          CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
          CreatedBy =Convert.ToInt32( reader["CreatedBy"].ToString()),
          LastModifiedBy = Convert.ToInt32(reader["LastModifiedBy"].ToString()),
          LastModifiedAt = Convert.ToDateTime(reader["LastModifiedAt"].ToString())
        };
      }
      return null;
    }
  }
}
