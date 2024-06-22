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
        
        
        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _customerQueryService.Handle(new GetAllCustomersQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/Customer/5
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
        
        //POST: api/Customer
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            var result =await _customerCommandService.Handle(command);
            return Ok(result);
        }
        
        //POST: api/Customer
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
