using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperTutorial.Contracts.v1.Requests;
using AutoMapperTutorial.Contracts.v1.Responses;
using AutoMapperTutorial.Domain;
using AutoMapperTutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperTutorial.Controllers.v1
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("/api/v1/orders/{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return Ok(orderResponse);
        }

        [HttpPost("api/v1/orders")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            var order = new Order
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderDate = createOrderRequest.OrderDate,
                OrderItems = createOrderRequest.OrderItems.ToList().Select(s => new OrderItem
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };
            await _orderService.CreateOrderAsync(order);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            var uri = "api/v1/orders/" + order.OrderId;
            return Created(uri, orderResponse);
        }
    }
}
