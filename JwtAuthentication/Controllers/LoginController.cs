namespace WebApi.Controllers;


using JwtAuthentication.Models;
using JwtAuthentication.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private IJwtService _jwtService;

    public LoginController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [Route("/Login")]
    [HttpPost]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _jwtService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

}
