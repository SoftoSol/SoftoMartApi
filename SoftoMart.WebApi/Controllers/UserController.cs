using Microsoft.AspNetCore.Mvc;

using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Exceptions;
using SoftoMart.Application.Services;
using SoftoMart.WebApi.RequestModel;
using SoftoMart.WebApi.ResponseModel;

using System;

namespace SoftoMart.WebApi.Controllers
{

  public class UserController : BaseController
  {
    private IUnitOfWorkFactory _UnitOfWorkFactory;
    private UserService _UserService;
    public UserService UserService => _UserService ??= new UserService(_UnitOfWorkFactory.Create());
    public UserController(IUnitOfWorkFactory unitOfWorkFactory){ _UnitOfWorkFactory = unitOfWorkFactory; }

    [HttpPost]
    [Route("CreateUpdate")]
    public IActionResult CreateUpdateUser(CreateUpdateUserRequestModel model)
    {
      try
      {
        if (model.DecryptedId > -1)
          return Ok(new CreateUpdateUserResponseModel(
            UserService.UpdateUser
            (model.DecryptedId,model.Username, model.Password, model.FirstName, model.LastName, model.Phone, base.GetUserId())
            ));
        else
          return Ok(new CreateUpdateUserResponseModel(
          UserService.CreateUser
          (model.Username, model.Password, model.FirstName, model.LastName, model.Phone, base.GetUserId())
          ));
      }
      catch(DuplicateException e)
      {
        return BadRequest(new { model.Username });
      }
      catch(Exception e)
      {
        return InternalServerError(e.Message);
      }
      }
  }
}
