using SoftoMart.Common;

using System.ComponentModel.DataAnnotations;

namespace SoftoMart.WebApi.RequestModel
{
  public abstract class CreateUpdatePersonRequestModel
  {
    public string Id { get; set; }
    public int DecryptedId { get => this.Id != null ? Utils.DecryptId(this.Id) : -1; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
  }
}
