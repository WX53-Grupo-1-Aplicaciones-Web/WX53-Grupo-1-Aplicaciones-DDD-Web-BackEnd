using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Publishing.Models.Commands.ProductCommands;
using Domain.Publishing.Models.Queries.ProductQueries;
using Domain.Publishing.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX_53_Artisania.Publishing.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;
        
        public ProductController(IProductQueryService productQueryService, IProductCommandService commandService,
            IMapper mapper)
        {
            _productCommandService = commandService;
            _productQueryService = productQueryService;
            _mapper = mapper;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _productQueryService .Handle(new GetAllProductsQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _productQueryService.Handle(new GetProductByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Product
        [HttpPost("create")]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _productCommandService.Handle(command);
            if (result > 0)
                return StatusCode(StatusCodes.Status201Created, result);
            return BadRequest();
        }
        
    }
}
