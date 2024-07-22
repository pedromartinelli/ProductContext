using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductContext.Api.Auth;
using ProductContext.Api.Extensions;
using ProductContext.Api.Responses;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.SessionDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Api.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionService _service;

        public SessionController(TokenService tokenService, ILogger<SessionController> logger, ISessionService service)
        {
            _tokenService = tokenService;
            _logger = logger;
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse<dynamic>(400, ModelState.GetErrors()));

            try
            {
                var user = await _service.LoginAsync(dto);

                var token = _tokenService.GenerateToken(user);

                return Ok(new ApiResponse<dynamic>(200, new { token }));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "Erro ao fazer login: {Message}", ex.Message);
                return Unauthorized(new ApiResponse<dynamic>(401, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "03EX1 - Erro ao fazer login");
                return StatusCode(500, new ApiResponse<dynamic>(500, "Falha interna no servidor"));
            }
        }
    }
}
