using SoftoMart.Common;
using SoftoMart.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.ResponseModel
{
  public class CreateUpdateUserResponseModel
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string Username { get; set; }
    public string Phone { get; set; }

    public CreateUpdateUserResponseModel(User user)
    {
      this.Id = Utils.EncryptId(user.Id);
      this.FirstName = user.FirstName;
      this.LastName = user.LastName;
      this.Username = user.Username;
      this.Phone = user.Phone;
    }
  }
}
