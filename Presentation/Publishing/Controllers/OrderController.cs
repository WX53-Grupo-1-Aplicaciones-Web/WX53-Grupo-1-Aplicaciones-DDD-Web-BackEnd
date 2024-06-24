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
    /// <summary>
    /// Controlador para gestionar las operaciones de las órdenes.
    /// </summary>
    /// <remarks>
    /// Proporciona endpoints para obtener todas las órdenes, obtener una orden por su ID y crear una nueva orden.
    /// </remarks>
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
        // GET: api/ordenes
        /// <summary>
        /// Obtiene todas las órdenes.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/ordenes
        ///
        /// </remarks>
        /// <returns>Una lista de órdenes si se encuentran.</returns>
        /// <response code="200">Retorna la lista de órdenes.</response>
        /// <response code="404">Si no se encuentran órdenes.</response>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _orderQueryService .Handle(new GetAllOrdersQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/ordenes/5
        /// <summary>
        /// Obtiene una orden por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/ordenes/{id}
        ///
        /// </remarks>
        /// <param name="id">El ID de la orden.</param>
        /// <returns>Los detalles de la orden si se encuentra.</returns>
        /// <response code="200">Retorna los detalles de la orden.</response>
        /// <response code="404">Si la orden no se encuentra.</response>
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _orderQueryService.Handle(new GetOrderByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/ordenes/create
        /// <summary>
        /// Crea una nueva orden.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     POST /api/ordenes/create
        ///     {
        ///        "productId": "123",
        ///        "product": "Product Name",
        ///        "parameters": [
        ///          {
        ///            "paramName": "Color",
        ///            "paramValue": "Red"
        ///          }
        ///        ],
        ///        "price": 100.0
        ///     }
        ///
        /// </remarks>
        /// <param name="command">El comando para crear una orden.</param>
        /// <returns>El ID de la orden creada si la creación es exitosa.</returns>
        /// <response code="201">Retorna el ID de la orden recién creada.</response>
        /// <response code="400">Si el comando es nulo o inválido.</response>
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
