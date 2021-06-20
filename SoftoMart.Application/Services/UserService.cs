using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Application.Services
{
  public class UserService
  {
    IUnitOfWork _UnitOfWork;
    public UserService(IUnitOfWork unitOfWork) { _UnitOfWork = unitOfWork; }
    public User CreateUser(string username, string password,  string firstname, string lastname,  string phone)
    {

      var user = new User
      {
        FirstName = firstname,
        LastName = lastname,
        Username = username,
        Password = password,
        Phone = phone
      };
      User newUser = null;
      using (_UnitOfWork)
      {
        try
        {
          if (_UnitOfWork.UserRepository.Create(user) > 0)
            newUser = _UnitOfWork.UserRepository.GetByUsername(username);
          _UnitOfWork.Commit();
        }
        catch(Exception e)
        {
          _UnitOfWork.Rollback();
        }
      }
      return newUser;
    }

    public User GetUser(string username)
    {
      User newUser = null;
      using (_UnitOfWork)
      {
        try
        {
          newUser = _UnitOfWork.UserRepository.GetByUsername(username);
          _UnitOfWork.Commit();
        }
        catch (Exception e)
        {
          _UnitOfWork.Rollback();
        }
      }
      return newUser;
    }
  //public User AuthenticateUser(string username, string password)
  //  {

  //  }
  
  }
  
}
