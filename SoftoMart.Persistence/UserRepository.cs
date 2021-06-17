using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Common;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SoftoMart.Persistence
{
  public class UserRepository : IUserRepository
  {
    public IUnitOfWork UnitOfWork { get; private set; }

    public UserRepository(IUnitOfWork unitOfWork)
    {
      this.UnitOfWork = unitOfWork;
    }
    public int Create(User entity)
    {
      var cmd= UnitOfWork.Connection.CreateCommand();
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
  }
}
