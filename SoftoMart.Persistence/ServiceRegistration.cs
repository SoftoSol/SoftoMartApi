using Microsoft.Extensions.DependencyInjection;

using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Persistence.Repositories;

namespace SoftoMart.Persistence
{
  public static class ServiceRegistration
  {
    public static void AddPersistenceInsfrastructure(this IServiceCollection services)
    {
      services.AddTransient<IUnitOfWorkFactory, SqlUnitOfWorkFactory>();
      //services.AddTransient<IUserRepository, UserRepository>();
      //services.AddTransient<IUserRepository, UserRepository>();
    }
  }
}
