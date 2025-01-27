using Microsoft.AspNetCore.Mvc;

namespace ProductContext.Api.Controllers;

[Route("")]
[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok("Hello World!");
    }
}
