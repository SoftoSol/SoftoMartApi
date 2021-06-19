using SoftoMart.Domain.Entities;

namespace SoftoMart.Application.Common.Contracts.Repositories
{
  public interface IUserRepository : IRepository<User>
  {
    User GetByUsername(string username);
  }
}
