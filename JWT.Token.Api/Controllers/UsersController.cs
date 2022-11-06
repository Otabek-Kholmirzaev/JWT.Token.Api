using JWT.Token.Api.Data;
using JWT.Token.Api.Entities;
using JWT.Token.Api.Models;
using JWT.Token.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWT.Token.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    private readonly IGetOptionsService _getOptionsService;

    public UsersController(AppDbContext context, IGetOptionsService getOptionsService)
    {
        _context = context;
        _getOptionsService = getOptionsService;
    }

    // this action returns all users data
    [HttpGet]
    public IActionResult GetData()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public IActionResult SignIn(SigninUserModel signinUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var users = _context.Users.ToList();

        if (!users.Any(u => u.Email == signinUserModel.Email && u.Password == signinUserModel.Password))
        {
            return Unauthorized();
        }

        var tokenKey = _getOptionsService.GetJwtOptions().Key;
        var keyByte = System.Text.Encoding.UTF8.GetBytes(tokenKey);   
        var securityKey = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);
        var security = new JwtSecurityToken(
            issuer: "Project-1",
            audience: "Room-1",
            new Claim[]
            {
                new Claim(ClaimTypes.Email, signinUserModel.Email)
            },
            expires: DateTime.Now.AddHours(4),
            signingCredentials: securityKey);

        var token = new JwtSecurityTokenHandler().WriteToken(security);

        return Ok(token);
    }

    [HttpPost("sign-up")]
    [AllowAnonymous]
    public IActionResult SignUp(CreateUserModel createUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Password = createUserModel.Password
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }
}
