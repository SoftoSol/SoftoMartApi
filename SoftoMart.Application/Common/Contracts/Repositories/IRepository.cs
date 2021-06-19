using System.Collections.Generic;
using System.Data;

namespace SoftoMart.Application.Common.Contracts.Repositories
{
  public interface IRepository<T>
  {
    IDbConnection Connection { get;}
    int Create(T entity);
    T Get(int id);
    List<T> Get();
    int Update(T entity);
    int Delete(T entity);

  }
}
