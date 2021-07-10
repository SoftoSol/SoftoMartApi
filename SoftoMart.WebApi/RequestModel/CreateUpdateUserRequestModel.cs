using SoftoMart.Common;

using System.ComponentModel.DataAnnotations;

namespace SoftoMart.WebApi.RequestModel
{
  public class CreateUpdateUserRequestModel
  {
    public string Id { get; set; }
    public int DecryptedId { get => this.Id!=null? Utils.DecryptId(this.Id):-1; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    //[RegularExpression("/^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,50}$/g",ErrorMessage = "Password must contain at least one small, one capital, one digit and one special character")]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
  }
}
