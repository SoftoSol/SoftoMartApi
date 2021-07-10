using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Persistence.Repositories
{
  public class SellerRepository : ISellerRepository
  {

    public IDbConnection Connection { get; private set; }
    public IDbTransaction Transaction { get; private set; }


    public SellerRepository(IDbConnection connection, IDbTransaction transaction)
    {
      Connection = connection;
      Transaction = transaction;
    }

    public int Create(Seller entity)
    {
      throw new NotImplementedException();
    }

    public int Delete(Seller entity)
    {
      throw new NotImplementedException();
    }

    public Seller Get(int id)
    {
      throw new NotImplementedException();
    }

    public List<Seller> Get()
    {
      throw new NotImplementedException();
    }

    public Seller GetByUserName(string username)
    {
      throw new NotImplementedException();
    }

    public int Update(Seller entity)
    {
      throw new NotImplementedException();
    }
  }
}
