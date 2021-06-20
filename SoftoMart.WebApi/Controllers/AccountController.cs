﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Services;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {

    private IConfiguration _Configuration;
    private IUnitOfWorkFactory _UnitOfWorkFactory;
    private UserService _UserService;
    public UserService UserService => _UserService ??= new UserService(_UnitOfWorkFactory.Create());
    public AccountController(IConfiguration configuration, IUnitOfWorkFactory unitOfWorkFactory) { 
      _Configuration = configuration;
      _UnitOfWorkFactory = unitOfWorkFactory;
    }

    [HttpGet]
    [Route("authenticate")]
    public IActionResult Authenticate(string username, string password)
    {
      var user = UserService.GetUser(username);
      string token = null;
      if (user != null)
        token = _GenerateToken(user.Id, user.Username);
      return Ok(token);
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
        issuer: null,
        audience: username,
        claims: claims,
        signingCredentials: hashedSecurityKey,
        expires: DateTime.UtcNow.AddMinutes(validityDuration)
        );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}