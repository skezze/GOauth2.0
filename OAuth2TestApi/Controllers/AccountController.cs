using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth2TestApi.Controllers;
[ApiController]
[AllowAnonymous,Route("account")]
[Route("api/account")]
public class AccountController:ControllerBase
{
    [Route("google-login")]
    [HttpGet]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleResponse")
        };
        return Challenge(properties,GoogleDefaults.AuthenticationScheme);
    }
    
    [Route("google-logout")]
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> GoogleLogout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
        {
            claim.Issuer,
            claim.OriginalIssuer,
            claim.Type,
            claim.Value
        });
        return new JsonResult(claims);
    }
}