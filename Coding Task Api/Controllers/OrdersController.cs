using Coding_Task_Api.Application.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coding_Task_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrdersController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new order for a customer.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                var orderId = await _mediator.Send(command);
                return Created("", new { orderId });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
