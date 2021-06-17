using System.Collections.Generic;

namespace SoftoMart.Application.Common.Contracts.Repositories
{
  public interface IRepository<T>
  {
    IUnitOfWork UnitOfWork { get;}
    int Create(T entity);
    T Get(int id);
    List<T> Get();
    int Update(T entity);
    int Delete(T entity);

  }
}
