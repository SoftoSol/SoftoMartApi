using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Exceptions;
using SoftoMart.Domain.Entities;

using System;

namespace SoftoMart.Application.Services
{
  public class UserService
  {
    IUnitOfWork _UnitOfWork;
    public UserService(IUnitOfWork unitOfWork) { _UnitOfWork = unitOfWork; }
    public User CreateUser(string username, string password,  string firstname, string lastname,  string phone, int? createdBy)
    {

      var user = new User
      {
        FirstName = firstname,
        LastName = lastname,
        Username = username,
        Password = password,
        Phone = phone,
        CreatedBy=createdBy
      };
      User newUser = null;
      using (_UnitOfWork)
      {
        try
        {
          if (_UnitOfWork.UserRepository.GetByUserName(username) != null)
            throw new DuplicateException("Username");
          if (_UnitOfWork.UserRepository.Create(user) > 0)
            newUser = _UnitOfWork.UserRepository.GetByUserName(username);
          _UnitOfWork.Commit();
        }
        catch(DuplicateException e)
        {
          _UnitOfWork.Rollback();
          throw e;
        }
        catch(Exception e)
        {
          _UnitOfWork.Rollback();
          throw new Exception(e.Message);
        }
      }
      return newUser;
    }
    public User UpdateUser(int Id, string username, string password, string firstname, string lastname, string phone, int? createdBy)
    {

      
      User newUser = null;
      using (_UnitOfWork)
      {
        try
        {
          var user = _UnitOfWork.UserRepository.Get(Id);
          if (user == null)
            throw new NotFoundException("User");
          if (_UnitOfWork.UserRepository.Update(user) > 0)
            newUser = _UnitOfWork.UserRepository.GetByUserName(username);
          _UnitOfWork.Commit();
        }
        catch (NotFoundException e)
        {
          _UnitOfWork.Rollback();
          throw e;
        }
        catch (Exception e)
        {
          _UnitOfWork.Rollback();
          throw new Exception(e.Message);
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
          newUser = _UnitOfWork.UserRepository.GetByUserName(username);
          _UnitOfWork.Commit();
        }
        catch (Exception e)
        {
          _UnitOfWork.Rollback();
        }
      }
      return newUser;
    }
    public User AuthenticateUser(string username, string password)
    {
      User user = null;
      using (_UnitOfWork)
      {
        try
        {
          user = _UnitOfWork.UserRepository.GetByUserName(username);
          if (user != null)
          {
            if (user.Password == password)
              return user;
          }
          return null;
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
          _UnitOfWork.Rollback();
        }
      }
      return user;
    }

  }
  
}
