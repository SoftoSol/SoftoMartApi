using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Application.Common.Contracts.Repositories
{
  public interface IPersonRepository<T>:IRepository<T>
  {
    T GetByUserName(string username);
  }
}
