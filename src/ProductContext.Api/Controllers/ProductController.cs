using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductContext.Api.Extensions;
using ProductContext.Api.Responses;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _service;

    public ProductController(ILogger<ProductController> logger, IProductService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<IActionResult> GetAsync([FromQuery] GetProductsRequestDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResponse<Product>(400, ModelState.GetErrors()));

        try
        {
            var result = await _service.GetAll(dto);
            return Ok(new ApiResponse<GetProductsResponseDto>(200, result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "01EX1 - Erro ao listar produtos");
            return StatusCode(500, new ApiResponse<Product>(500, "Falha interna no servidor"));
        }
    }

    [HttpGet("{id:Guid}", Name = "GetProduct")]
    public async Task<IActionResult> GetOneAsync([FromRoute] Guid id)
    {
        try
        {
            var result = await _service.GetById(id);
            return Ok(new ApiResponse<Product>(200, result));
        }
        catch (ApplicationException ex)
        {
            _logger.LogWarning(ex, "Erro ao buscar produto: {id}", id);
            return NotFound(new ApiResponse<Product>(404, ex.Message));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "01EX2 - Erro ao buscar produto");
            return StatusCode(500, new ApiResponse<Product>(500, "Falha interna no servidor"));
        }
    }

    [HttpPost(Name = "CreateProduct")]
    [Authorize]
    public async Task<IActionResult> PostAsync([FromBody] CreateProductRequestDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResponse<Product>(400, ModelState.GetErrors()));

        try
        {
            var result = await _service.Create(dto);
            return CreatedAtRoute("GetProduct", new { id = result.Id }, result);
        }
        catch (ApplicationException ex)
        {
            _logger.LogWarning(ex, "Conflito ao criar produto: {Message}", ex.Message);
            return Conflict(new ApiResponse<Product>(409, ex.Message));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "01EX3 - Erro ao cadastrar produto");
            return StatusCode(500, new ApiResponse<Product>(500, "Falha interna no servidor"));
        }
    }
}
