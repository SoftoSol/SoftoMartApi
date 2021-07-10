
using Microsoft.AspNetCore.Mvc;

using SoftoMart.WebApi.RequestModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.Controllers
{

  public class SellerController:BaseController
  {
    [HttpPost]
    [Route("CreateUpdate")]
    public IActionResult CreateUpdateSeller(CreateUpdateSellerRequestModel model)
    {
      return Ok();
    }
  }
}
