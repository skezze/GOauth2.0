using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth2TestApi.Controllers;
[ApiController]
[Route("api/home")]
public class HomeController:ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [Route("home")]
    public IActionResult Home()
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("authcheck")]
    [Authorize]
    public IActionResult AuthCheck()
    {
        return Ok();
    }
}