using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SoftoMart.Application.Common.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.Controllers
{
  public class BaseController : ControllerBase
  {
    private string GenerateIPAddress()
    {
      if (Request.Headers.ContainsKey("X-Forwarded-For"))
        return Request.Headers["X-Forwarded-For"];
      else
        return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
  }
}
