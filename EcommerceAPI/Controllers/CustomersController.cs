using AutoMapper;
using EcommerceAPI.Models.Domain;
using EcommerceAPI.Models.DTO;
using EcommerceAPI.Repositories;
using ECommerceAPI.Data;
using ECommerceAPI.Models;
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
        // GET: https://localhost:7143/api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var customersDomain = await customerRepository.GetAllAsync();

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
        public async Task<IActionResult> Create([FromBody] AddCustomerRequestDTO addCustomerRequestDTO)
        {
            // Map or Convert DTO to Domain Model
            var customerDomainModel = mapper.Map<Customer>(addCustomerRequestDTO);

            // Use Domain Model to create Customer
            customerDomainModel = await customerRepository.CreateAsync(customerDomainModel);

            // Map Domain Model back to DTO
            var customerDto = mapper.Map<CustomerDTO>(customerDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = customerDto.UserId }, customerDto);
        }
    }
}
