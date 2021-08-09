using SoftoMart.Application.Common.Contracts;
using SoftoMart.Application.Common.Contracts.Repositories;
using SoftoMart.Application.Common.Exceptions;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftoMart.Application.Services
{
  public class SellerService
  {
    private IUnitOfWork _UnitOfWork;
    private ILogger _Logger;
    private ISellerRepository _Repo => _UnitOfWork.SellerRepository;
    public SellerService(IUnitOfWork unitOfWork, ILogger logger)
    {
      _UnitOfWork = unitOfWork;
      _Logger = logger;
    }

    public Seller Create(Seller seller)
    {
      try
      {
        if (_Repo.GetByUserName(seller.Username) is not null)
          throw new DuplicateUsernameException(seller.Username);
        if (_Repo.Create(seller) > 0)
          seller = _Repo.GetByUserName(seller.Username);
        _UnitOfWork.Commit();
        return seller;
      }
      catch (DuplicateUsernameException exception)
      {
        _UnitOfWork.Rollback();
        _Logger.Log(exception);
        throw exception;
      }
      catch (Exception exception)
      {
        _UnitOfWork.Rollback();
        _Logger.Log(exception);
        throw exception;
      }
    }
  }
}
