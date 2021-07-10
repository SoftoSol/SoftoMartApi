using SoftoMart.Common;
using SoftoMart.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftoMart.WebApi.ResponseModel.Common
{
  public abstract class CreateUpdatePersonBaseResponseModel
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string Username { get; set; }
    public string Phone { get; set; }

    public CreateUpdatePersonBaseResponseModel(PersonBaseEntity person)
    {
      this.Id = Utils.EncryptId(person.Id);
      this.FirstName = person.FirstName;
      this.LastName = person.LastName;
      this.Username = person.Username;
      this.Phone = person.Phone;
    }
  }
}
