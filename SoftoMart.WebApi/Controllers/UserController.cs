using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : BaseController
  {
    private IUnitOfWorkFactory _UnitOfWorkFactory;
    private UserService _UserService;
    public UserService UserService => _UserService ??= new UserService(_UnitOfWorkFactory.Create());
    public UserController(IUnitOfWorkFactory unitOfWorkFactory){ _UnitOfWorkFactory = unitOfWorkFactory; }

    [HttpPost]
    [Route("Create")]
    public IActionResult CreateUser(string username, string firstname, string lastname, string password, string phone)
    {
      return Ok(UserService.CreateUser(username, password, firstname, lastname, phone));
    }
  }
}
