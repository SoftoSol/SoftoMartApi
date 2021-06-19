using Microsoft.Extensions.DependencyInjection;

using SoftoMart.Application.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Application.Common
{
  public static class ServiceExtension
  {
    public static void AddApplicationInfrastructure(this IServiceCollection service)
    {
      //service.AddTransient<UserService>();
    }
  }
}
