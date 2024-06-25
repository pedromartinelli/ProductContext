using Microsoft.AspNetCore.Mvc;
using ProductContext.Api.Extensions;
using ProductContext.Api.Responses;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Api.Controllers;

[ApiController]
[Route("products")]
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
    public async Task<IActionResult> GetAsync([FromQuery] GetProductsDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResponse<Product>(400, ModelState.GetErrors()));

        try
        {
            var result = await _service.GetAsync(dto);
            return Ok(new ApiResponse<GetProductsResponseDto>(200, result));
        }
        catch
        {
            return StatusCode(500, new ApiResponse<Product>(500, "01EX1 - Falha interna no servidor"));
        }
    }

    [HttpGet("{id:Guid}", Name = "GetProduct")]
    public async Task<IActionResult> GetOneAsync([FromRoute] Guid id)
    {
        try
        {
            var result = await _service.GetAsync(id);
            return Ok(new ApiResponse<Product>(200, result));
        }
        catch (ApplicationException ex)
        {
            return NotFound(new ApiResponse<Product>(404, ex.Message));
        }
        catch
        {
            return StatusCode(500, new ApiResponse<Product>(500, "01EX2 - Falha interna no servidor"));
        }
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<IActionResult> PostAsync([FromBody] CreateProductDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResponse<Product>(400, ModelState.GetErrors()));

        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtRoute("GetProduct", new { id = result.Id }, result);
        }
        catch (ApplicationException ex)
        {
            return Conflict(new ApiResponse<Product>(404, ex.Message));
        }
        catch
        {
            return StatusCode(500, new ApiResponse<Product>(500, "01EX3 - Falha interna no servidor"));
        }
    }
}
