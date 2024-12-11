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
    // https://localhost:7143/api/orders
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderController(ApplicationDbContext dbContext, IOrderRepository orderRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        // GET ALL ORDERs
        // GET: https://localhost:7143/api/orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var orderDomain = await orderRepository.GetAllAsync();

            // Map Domain Models to DTOs and Return DTOs
            return Ok(mapper.Map<List<OrderDTO>>(orderDomain));
        }

        // GET SINGLE ORDER (Get Order By ID)
        // GET: https://localhost:7143/api/orders/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Order Domain Model From Database
            var orderDomain = await orderRepository.GetByGuidAsync(id);

            if (orderDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<OrderDTO>(orderDomain));
        }

        // POST To Create New Order
        // POST: https://localhost:7143/api/orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDTO addOrderRequestDTO)
        {
            // Map or Convert DTO to Domain Model
            var orderDomainModel = mapper.Map<Order>(addOrderRequestDTO);

            // Use Domain Model to create Order
            orderDomainModel = await orderRepository.CreateAsync(orderDomainModel);

            // Map Domain Model back to DTO
            var orderDto = mapper.Map<OrderDTO>(orderDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = orderDto.OrderID}, orderDto);
        }

        // Update Customer
        // PUT: https://localhost:7143/api/customers/{id}
        [HttpPut]
        [Route("{id:Guid}")]
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
