using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace JWT.Token.Api.Models;

public class CreateUserModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }    
}
