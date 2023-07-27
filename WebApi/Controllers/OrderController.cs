using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.OrderOperations.Commands.CreateOrder;
using WebApi.Applications.OrderOperations.Commands.DeleteOrder;
using WebApi.Applications.OrderOperations.Commands.UpdateOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrderDetail;
using WebApi.Applications.OrderOperations.Queries.GetOrder;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]

    public class OrderController: ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetListOrderQuery query = new GetListOrderQuery(_context, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = id;

            
            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = model;

          
            command.Handle();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] UpdateOrderModel model, int Id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);
            command.Model = model;
            command.OrderId = Id;
            
            command.Handle();

            return Ok();
        }

        [HttpPut("softDelete/{Id}")]
        public IActionResult SoftDelete([FromRoute] int Id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);

            command.OrderId = Id;
            command.Handle();

            return Ok();
        }

    }
}