using AutoMapper;
using EcommerceAPI.Models.Domain;
using EcommerceAPI.Models.DTO;
using EcommerceAPI.Repositories;
using EcommerceAPI.CustomActionFilters;
using ECommerceAPI.Data;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    // https://localhost:7143/api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(ApplicationDbContext dbContext, IProductRepository productRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        // GET ALL PRODUCTS
        // GET: https://localhost:7143/api/product?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            // Get Data From Database - Domain models
            var productDomain = await productRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            // Map Domain Models to DTOs and Return DTOs
            return Ok(mapper.Map<List<ProductDTO>>(productDomain));
        }

        // GET SINGLE PRODUCT (Get Product By ID)
        // GET: https://localhost:7143/api/product/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Product Domain Model From Database
            var productDomain = await productRepository.GetByGuidAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<ProductDTO>(productDomain));
        }

        // POST To Create New Product
        // POST: https://localhost:7143/api/product
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDTO addProductRequestDTO)
        {
            // Map or Convert DTO to Domain Model
            var productDomainModel = mapper.Map<Product>(addProductRequestDTO);

            // Use Domain Model to create Product
            productDomainModel = await productRepository.CreateAsync(productDomainModel);

            // Map Domain Model back to productDomainModel
            var productDto = mapper.Map<ProductDTO>(productDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = productDto.ProductID }, productDto);
        }

        // Update Product
        // PUT: https://localhost:7143/api/product/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO updateProductRequestDto)
        {
            // Map DTO to Domain Model
            var productDomainModel = mapper.Map<Product>(updateProductRequestDto);

            // Check if product exists
            productDomainModel = await productRepository.UpdateAsync(id, productDomainModel);

            if (productDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductDTO>(productDomainModel));
        }

        // Delete Product
        // DELETE: https://localhost:7143/api/product/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO updateProductRequestDto)
        {
            var productDomainModel = await productRepository.DeleteAsync(id);

            if (productDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductDTO>(productDomainModel));
        }
    }
}
