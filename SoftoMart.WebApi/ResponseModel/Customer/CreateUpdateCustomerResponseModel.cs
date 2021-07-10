using SoftoMart.WebApi.ResponseModel.Common;

namespace SoftoMart.WebApi.ResponseModel.Customer
{
  public class CreateUpdateCustomerResponseModel:CreateUpdatePersonBaseResponseModel
  {
    public CreateUpdateCustomerResponseModel(Domain.Entities.Customer customer):base(customer){}
  }
}
