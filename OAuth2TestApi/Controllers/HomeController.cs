using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth2TestApi.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public class HomeController:ControllerBase
{
    [HttpGet]
    public IActionResult getHome()
    {
        return Ok();
    }
}