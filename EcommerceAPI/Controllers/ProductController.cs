using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Services;
using EcommerceAPI.Models.Domain;

namespace ECommerceAPI.Controllers;

// Receives product requests (POST /product).
// Uses ProductService to keep inventory of products.
// Sends the appropriate response (success or failure, with messages or tokens).

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll() =>
        ProductService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Product> Get(Guid id)
    {
        var product = ProductService.Get(id);

        if(product == null)
            return NotFound();

        return product;
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {            
        ProductService.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.ProductID }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Product product)
    {
        if (id != product.ProductID)
            return BadRequest();
            
        var existingProduct = ProductService.Get(id);
        if (existingProduct is null)
            return NotFound();
    
        ProductService.Update(product);
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var product = ProductService.Get(id);
    
        if (product is null)
            return NotFound();
        
        ProductService.Delete(id);
    
        return NoContent();
    }
}
