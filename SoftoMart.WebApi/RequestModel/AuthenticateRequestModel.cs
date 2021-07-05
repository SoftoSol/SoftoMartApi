using System.ComponentModel.DataAnnotations;

namespace SoftoMart.WebApi.RequestModel
{
  public class AuthenticateRequestModel
  {
    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string Username { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string Password { get; set; }
  }
}
