using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Models.Queries.CustomerQueries;
using Domain.Publishing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX_53_Artisania.Publishing.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones de los clientes.
    /// </summary>
    /// <remarks>
    /// Proporciona endpoints para obtener todos los clientes, obtener un cliente por su ID, crear un nuevo cliente, iniciar sesión, registrar y actualizar la información del cliente.
    /// </remarks>
    [Route("api/clientes")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ICustomerCommandService _customerCommandService;
        private readonly ICustomerQueryService _customerQueryService;
        
        public CustomerController(ICustomerQueryService customerQueryService, ICustomerCommandService customerCommandService,
            IMapper mapper)
        {
            _customerQueryService = customerQueryService;
            _customerCommandService = customerCommandService;
            _mapper = mapper;
        }
        
        
        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/clientes
        ///
        /// </remarks>
        /// <returns>Una lista de clientes si se encuentran.</returns>
        /// <response code="200">Retorna la lista de clientes.</response>
        /// <response code="404">Si no se encuentran clientes.</response>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _customerQueryService.Handle(new GetAllCustomersQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/clientes/{id}
        ///
        /// </remarks>
        /// <param name="id">El ID del cliente.</param>
        /// <returns>Los detalles del cliente si se encuentra.</returns>
        /// <response code="200">Retorna los detalles del cliente.</response>
        /// <response code="404">Si el cliente no se encuentra.</response>
        [HttpGet("{id}", Name = "GetAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _customerQueryService.Handle(new GetCustomerByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Customer
        [HttpPost("create"),]
        public async Task<IActionResult> PostAsync([FromBody] CreateCustomerCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _customerCommandService.Handle(command);
            if (result > 0)
                return StatusCode(StatusCodes.Status201Created, result);

            return BadRequest();
        }
        
        /// <summary>
        /// Inicia sesión un cliente existente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     POST /api/clientes/login
        ///     {
        ///        "username": "johndoe",
        ///        "password": "password123"
        ///     }
        ///
        /// </remarks>
        /// <param name="command">El comando de inicio de sesión.</param>
        /// <returns>Un token de acceso si el inicio de sesión es exitoso.</returns>
        /// <response code="200">Retorna el token de acceso recién creado.</response>
        /// <response code="400">Si el comando es nulo o inválido.</response>
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            var result =await _customerCommandService.Handle(command);
            return Ok(result);
        }
        
        /// <summary>
        /// Registra un nuevo cliente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     POST /api/clientes/register
        ///     {
        ///        "usuario": "johndoe",
        ///        "contraseña": "password123",
        ///        "correo": "johndoe@example.com",
        ///        "imagenUsuario": "http://example.com/image.jpg",
        ///        "isArtisan": true,
        ///        "role": "user"
        ///     } 
        ///
        /// </remarks>
        /// <param name="command">El comando de registro.</param>
        /// <returns>Un token de acceso si el registro es exitoso.</returns>
        /// <response code="200">Retorna el token de acceso recién creado.</response>
        /// <response code="400">Si el comando es nulo o inválido.</response>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]SignUpCommand command)
        {
            if (command.Role == null)
            {
                command.Role = "user";
            }
            var result = await _customerCommandService.Handle(command);
            return Ok(result);
        }
        
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateCustomerCommand command)
        {
            command.Id = id;
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _customerCommandService.Handle(command); 
            
            if (result)
                return Ok();
            else
                return BadRequest();
        }
        
        // PUT: api/Customer/5/password
        [HttpPut("{id}/password")]
        public async Task<IActionResult> UpdatePasswordAsync(int id, [FromBody] UpdateCustomerPasswordCommand command)
        {
            command.Id = id;
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _customerCommandService.Handle(command);

            if (result)
                return Ok();
            else
                return BadRequest();
        }
        
    }
}
