using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SoftoMart.Application.Common.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.Controllers
{
  [Authorize]
  public class BaseController : ControllerBase
  {
    protected int? GetUserId()
    {
      try
      {
        return int.Parse(User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value);
      }
      catch
      {
        return null;
      }
    }
    protected string GenerateIPAddress()
    {
      if (Request.Headers.ContainsKey("X-Forwarded-For"))
        return Request.Headers["X-Forwarded-For"];
      else
        return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }

    protected IActionResult InternalServerError() { return StatusCode(500); }
    protected IActionResult InternalServerError(string message) { return StatusCode(500,message); }
    protected IActionResult InternalServerError(object exception) { return StatusCode(500,exception); }
    //protected IActionResult BadRequest(object exception) { return StatusCode(400,exception); }

  }
}
