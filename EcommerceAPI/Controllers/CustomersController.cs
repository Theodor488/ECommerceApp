using AutoMapper;
using EcommerceAPI.Repositories;
using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Models.DTO;
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
        // GET: https://localhost:7143/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain = await customerRepository.GetAllAsync();

            // Map Domain Models to DTOs and Return DTOs
            return Ok(mapper.Map<List<CustomerDTO>>(regionsDomain));
        }
    }
}
