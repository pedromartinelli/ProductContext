using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductContext.Api.Extensions;
using ProductContext.Api.Responses;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.UserDtos;
using ProductContext.Domain.Entities;


namespace ProductContext.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _service = userService;
            _logger = logger;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse<User>(400, ModelState.GetErrors()));

            try
            {
                var result = await _service.CreateAsync(dto);
                return CreatedAtRoute("GetUser", new { id = result.Id }, result);
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "Conflito ao criar usuário: {Message}", ex.Message);
                return Conflict(new ApiResponse<User>(409, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "02EX1 - Erro ao cadastrar usuário");
                return StatusCode(500, new ApiResponse<User>(500, "Falha interna no servidor"));
            }
        }

        [HttpGet("{id:Guid}", Name = "GetUser")]
        public async Task<IActionResult> GetOneAsync([FromRoute] Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(new ApiResponse<User>(200, result));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "Erro ao buscar usuário: {id}", id);
                return NotFound(new ApiResponse<User>(404, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "01EX2 - Erro ao buscar usuário");
                return StatusCode(500, new ApiResponse<User>(500, "Falha interna no servidor"));
            }
        }

        [HttpGet("claim")]
        [Authorize]
        public async Task<IActionResult> GetUserClaimAsync()
        {
            try
            {
                var user = HttpContext.GetEmailClaim();
                var result = await _service.GetByEmailAsync(user);
                return Ok(new ApiResponse<User>(200, result));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "Erro ao buscar usuário: {id}", ex);
                return NotFound(new ApiResponse<User>(404, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "01EX2 - Erro ao buscar usuário");
                return StatusCode(500, new ApiResponse<User>(500, "Falha interna no servidor"));
            }
        }
    }
}
