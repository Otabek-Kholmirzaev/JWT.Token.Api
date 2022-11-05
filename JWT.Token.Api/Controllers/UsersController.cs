using JWT.Token.Api.Models;
using JWT.Token.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Token.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Login(UserLoginModel userLoginModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(userLoginModel);

        return Ok(userLoginModel);
    }
}
