using Microsoft.AspNetCore.Mvc;
using ProductContext.Api.Extensions;
using ProductContext.Api.Results;
using ProductContext.Domain.Dtos.Product;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces.Services;

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

    [HttpPost(Name = "CreateProduct")]
    public async Task<IActionResult> PostAsync([FromBody] CreateProductDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResult<Product>(400, ModelState.GetErrors()));

        try
        {
            await _service.CreateAsync(dto);
            return StatusCode(201);
        }
        catch (ApplicationException ex)
        {
            return NotFound(new ApiResult<Product>(404, ex.Message));
        }
        catch
        {
            return StatusCode(500, new ApiResult<Product>(500, "02EX5 - Falha interna no servidor"));
        }
    }
}
