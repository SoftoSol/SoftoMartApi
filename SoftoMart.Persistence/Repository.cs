using SoftoMart.Application.Common.Contracts.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Persistence
{
  public class Repository<T> : IRepository<T>
  {
    public T Create(T entity)
    {
      throw new NotImplementedException();
    }

    public T Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public T Get(int id)
    {
      throw new NotImplementedException();
    }

    public List<T> Get()
    {
      throw new NotImplementedException();
    }

    public T Update(T entity)
    {
      throw new NotImplementedException();
    }
  }
}
