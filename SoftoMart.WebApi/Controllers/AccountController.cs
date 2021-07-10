using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Services;
using SoftoMart.WebApi.ResponseModel;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftoMart.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {

    private IUnitOfWorkFactory _UnitOfWorkFactory;
    private UserService _UserService;
    public UserService UserService => _UserService ??= new UserService(_UnitOfWorkFactory.Create());
    public AccountController(IUnitOfWorkFactory unitOfWorkFactory) { 
      _UnitOfWorkFactory = unitOfWorkFactory;
    }

    [HttpGet]
    [Route("authenticate")]
    public IActionResult Authenticate(string username, string password)
    {
      var user = UserService.AuthenticateUser(username, password);
      if (user == null)
        return Unauthorized();
      string token = null;
      if (user != null)
        token = _GenerateToken(user.Id, user.Username);
      return Ok(new AuthenticateResponseModel { AccessToken = token, FirstName = user.FirstName, LastName = user.LastName, Username = user.Username });
    }

    private string _GenerateToken(int id, string username)
    {
      int validityDuration = 60;
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-terrible-security-secret"));
      var hashedSecurityKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Name, username),
        new Claim(JwtRegisteredClaimNames.NameId, id.ToString())
      };
      var token = new JwtSecurityToken(
        issuer: "test",
        audience: "audience",
        claims: claims,
        signingCredentials: hashedSecurityKey,
        expires: DateTime.UtcNow.AddMinutes(validityDuration)
        );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}