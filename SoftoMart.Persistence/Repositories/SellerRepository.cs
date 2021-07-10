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
  public class SellerRepository : BaseRepository,ISellerRepository
  {

    public IDbConnection Connection { get; private set; }
    private IDbTransaction _Transaction { get; set; }


    public SellerRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
    {
      Connection = connection;
      _Transaction = transaction;
    }

    public int Create(Seller entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.CreateSeller;
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pUsername", entity.Username));
      cmd.Parameters.Add(new SqlParameter("@pCreatedBy", entity.CreatedBy));
      return cmd.ExecuteNonQuery();
    }

    public int Delete(Seller entity)
    {
      return base.Delete(entity, SqlProcedures.DeleteSeller);
    }

    public Seller Get(int id)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetSeller;
      cmd.Parameters.Add(new SqlParameter("@pId", id));
      using (var reader = cmd.ExecuteReader())
      {
        if (reader is null || reader.FieldCount is 0)
          return null;
        return SellerUtils.MapSeller(reader);
      }
    }

    public List<Seller> Get()
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.GetSellers;
      using (var reader = cmd.ExecuteReader())
      {
        if (reader is null || reader.FieldCount is 0)
          return null;
        var sellers = new List<Seller>();
        while (reader.Read())
        {
          sellers.Add(SellerUtils.MapSeller(reader));
        }
        return sellers;
      }
    }

    public Seller GetByUserName(string username)
    {
      var command = Connection.CreateCommand(_Transaction);
      command.CommandText = SqlProcedures.GetSellerByUsername;
      command.Parameters.Add(new SqlParameter("@pUsername", username));
      using (var reader = command.ExecuteReader())
      {
        if (!reader.Read())
        {
          reader.Close();
          return null;
        }
        return SellerUtils.MapSeller(reader);
      }
    }

    public int Update(Seller entity)
    {
      var cmd = Connection.CreateCommand(_Transaction);
      cmd.CommandText = SqlProcedures.UpdateSeller;
      cmd.Parameters.Add(new SqlParameter("@pId", entity.Id));
      cmd.Parameters.Add(new SqlParameter("@pFirstName", entity.FirstName));
      cmd.Parameters.Add(new SqlParameter("@pLastName", entity.LastName));
      cmd.Parameters.Add(new SqlParameter("@pPhone", entity.Phone));
      cmd.Parameters.Add(new SqlParameter("@pModifiedBy", entity.LastModifiedBy));
      return cmd.ExecuteNonQuery();
    }
  }
  internal static class SellerUtils
  {
    internal static Seller MapSeller(IDataReader reader)
    {
      if (!reader.Read())
        return null;
      return new Seller
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
  }
}
