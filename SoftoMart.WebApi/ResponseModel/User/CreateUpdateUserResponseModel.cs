using SoftoMart.Domain.Entities;
using SoftoMart.WebApi.ResponseModel.Common;

namespace SoftoMart.WebApi.ResponseModel
{
  public class CreateUpdateUserResponseModel:CreateUpdatePersonBaseResponseModel
  {
    public CreateUpdateUserResponseModel(User user):base(user) { }
  }
}
