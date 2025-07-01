using Coding_Task_Api.Application.Customer;
using Coding_Task_Api.Application.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Coding_Task_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public CustomersController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a new customer.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            try
            {
                var customerId = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetCustomerOrders), new { id = customerId }, new { customerId });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return BadRequest(new { Message = ex.Message });
            }
        }
        /// <summary>
        /// Gets all orders for a specific customer order by older to newer.
        /// </summary>
        /// <param name="id">The customer's ID.</param>
        [HttpGet("{id:guid}/orders")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerOrders(Guid id)
        {
            try
            {
                var query = new GetCustomerOrdersQuery(id);
                var orders = await _mediator.Send(query);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });

            }
        }
        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            try
            {
                var command = new UpdateCustomerCommand(
                   id,
                   request.FirstName,
                   request.LastName,
                   request.Street,
                   request.City,
                   request.PostalCode);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return NotFound(new { Message = ex.Message });
            }
        }
        // <summary>
        /// Deletes a customer.
        /// </summary>
        /// <remarks>A customer cannot be deleted if they have existing orders.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try {
                await _mediator.Send(new DeleteCustomerCommand(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Customer with ID"))
                {
                    return NotFound(new { Message = ex.Message });
                }
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
