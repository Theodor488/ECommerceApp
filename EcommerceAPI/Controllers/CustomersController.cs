using AutoMapper;
using EcommerceAPI.CustomActionFilters;
using ECommerceAPI.Data;
using EcommerceAPI.Models.Domain;
using EcommerceAPI.Models.DTO;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcommerceAPI.Controllers
{
    // https://localhost:7143/api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomersController(ApplicationDbContext dbContext, ICustomerRepository customerRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        // GET ALL CUSTOMERS
        // GET: https://localhost:7143/api/customers?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            // Get Data From Database - Domain models
            var customersDomain = await customerRepository.GetAllAsync(filterOn, filterQuery);

            // Map Domain Models to DTOs and Return DTOs
            return Ok(mapper.Map<List<CustomerDTO>>(customersDomain));
        }

        // GET SINGLE CUSTOMER (Get Customer By ID)
        // GET: https://localhost:7143/api/customers/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Customer Domain Model From Database
            var customersDomain = await customerRepository.GetByGuidAsync(id);

            if (customersDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<CustomerDTO>(customersDomain));
        }

        // POST To Create New Customer
        // POST: https://localhost:7143/api/customers
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddCustomerRequestDTO addCustomerRequestDTO)
        {
            // Map or Convert DTO to Domain Model
            var customerDomainModel = mapper.Map<Customer>(addCustomerRequestDTO);

            // Use Domain Model to create Customer
            customerDomainModel = await customerRepository.CreateAsync(customerDomainModel);

            // Map Domain Model back to DTO
            var customerDto = mapper.Map<CustomerDTO>(customerDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = customerDto.CustomerID }, customerDto);
        }

        // Update Customer
        // PUT: https://localhost:7143/api/customers/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequestDTO updateCustomerRequestDto)
        {
            // Map DTO to Domain Model
            var customerDomainModel = mapper.Map<Customer>(updateCustomerRequestDto);

            // Check if customer exists
            customerDomainModel = await customerRepository.UpdateAsync(id, customerDomainModel);

            if (customerDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CustomerDTO>(customerDomainModel));
        }

        // Delete Customer
        // DELETE: https://localhost:7143/api/customers/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromBody] UpdateCustomerRequestDTO updateCustomerRequestDto)
        {
            var customerDomainModel = await customerRepository.DeleteAsync(id);

            if (customerDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CustomerDTO>(customerDomainModel));
        }
    }
}
