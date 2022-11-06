using System.ComponentModel.DataAnnotations;

namespace JWT.Token.Api.Models;

public class SigninUserModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
