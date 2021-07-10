using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data;

namespace SoftoMart.Persistence.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    public IDbConnection Connection { get; private set; }
    public IDbTransaction Transaction { get; private set; }
    public CustomerRepository(IDbConnection connection, IDbTransaction transaction)
    {
      Connection = connection;
      Transaction = transaction;
    }

    public int Create(Customer entity)
    {
      throw new NotImplementedException();
    }

    public int Delete(Customer entity)
    {
      throw new NotImplementedException();
    }

    public Customer Get(int id)
    {
      throw new NotImplementedException();
    }

    public List<Customer> Get()
    {
      throw new NotImplementedException();
    }

    public int Update(Customer entity)
    {
      throw new NotImplementedException();
    }
  }
}
