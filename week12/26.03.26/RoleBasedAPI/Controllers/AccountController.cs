using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private static Account account = new Account
    {
        Id = 1,
        Name = "Diksha",
        Email = "diksha0211@gmail.com",
        Password = "0987",
        Balance = 1200000
    };

    [HttpGet("login")]
    public IActionResult Login(string role)
    {
        var tokenService = new TokenService();
        var token = tokenService.CreateToken("Atul", role);

        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("details")]
    public IActionResult GetDetails()
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role == "Admin")
        {
            return Ok(new AdminAccountDTO
            {
                Name = account.Name,
                Email = account.Email,
                Balance = account.Balance
            });
        }

        return Ok(new UserAccountDTO
        {
            Name = account.Name
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-only")]
    public IActionResult AdminOnly()
    {
        return Ok("Admin access only");
    }
}