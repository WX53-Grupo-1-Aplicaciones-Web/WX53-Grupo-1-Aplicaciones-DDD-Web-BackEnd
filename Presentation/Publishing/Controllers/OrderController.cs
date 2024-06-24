using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Publishing.Models.Commands.OrderCommands;
using Domain.Publishing.Models.Queries.OrderQueries;
using Domain.Publishing.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX_53_Artisania.Publishing.Controllers
{
    [Route("api/ordenes")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderCommandService _orderCommandService;
        private readonly IOrderQueryService _orderQueryService;
        
        public OrderController(IOrderQueryService orderQueryService, IOrderCommandService commandService,
            IMapper mapper)
        {
            _orderCommandService = commandService;
            _orderQueryService = orderQueryService;
            _mapper = mapper;
        }
        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _orderQueryService .Handle(new GetAllOrdersQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _orderQueryService.Handle(new GetOrderByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Order
        [HttpPost("create")]
        public async Task<IActionResult> PostAsync([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _orderCommandService.Handle(command);
            if (result > 0)
                return StatusCode(StatusCodes.Status201Created, result);
            return BadRequest();
        }
        
    }
}
