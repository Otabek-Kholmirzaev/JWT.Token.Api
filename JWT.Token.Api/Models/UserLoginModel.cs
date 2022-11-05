using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace JWT.Token.Api.Models;

public class UserLoginModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }    
}
