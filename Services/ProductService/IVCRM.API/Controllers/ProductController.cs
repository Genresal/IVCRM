using IVCRM.BLL.Managers;
using IVCRM.BLL.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IVCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IManager<BaseProduct> _productManager;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IManager<BaseProduct> productManager,
        ILogger<ProductController> logger)
    {
        _productManager = productManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> CreateProductAsync([FromBody] CreateProductRequest request)
    {
        return Ok(await _productManager.CreateAsync(request, HttpContext.RequestAborted));
    }

    [HttpPut]
    public async Task<ActionResult<ProductResponse>> UpdateProductAsync([FromBody] UpdateProductRequest request)
    {
        _logger.LogInformation(
            @"Update the product with id: {id} 
                with the data : {data}",
            request.Id,
            JsonSerializer.Serialize(request));

        return Ok(await _productManager.UpdateAsync(request, HttpContext.RequestAborted));
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync([FromQuery] ProductRequest request)
    {
        return Ok(await _productManager.GetPagedAsync(request, HttpContext.RequestAborted));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync([FromRoute] long id)
    {
        return Ok(await _productManager.GetDetailsAsync(id, HttpContext.RequestAborted));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] long id)
    {
        await _productManager.DeleteAsync(id, HttpContext.RequestAborted);

        return Ok();
    }
}
