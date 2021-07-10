using SoftoMart.WebApi.ResponseModel.Common;

namespace SoftoMart.WebApi.ResponseModel.Seller
{
  public class CreateUpdateSellerResponseModel:CreateUpdatePersonBaseResponseModel
  {
    public CreateUpdateSellerResponseModel(Domain.Entities.Seller  seller) :base(seller){}
  }
}
