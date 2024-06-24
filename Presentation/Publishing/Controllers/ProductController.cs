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
    /// <summary>
    /// Controlador para gestionar las operaciones de los productos.
    /// </summary>
    /// <remarks>
    /// Proporciona endpoints para obtener todos los productos, obtener un producto por su ID y crear un nuevo producto.
    /// </remarks>
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
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/productos
        ///
        /// </remarks>
        /// <returns>Una lista de productos si se encuentran.</returns>
        /// <response code="200">Retorna la lista de productos.</response>
        /// <response code="404">Si no se encuentran productos.</response>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _productQueryService .Handle(new GetAllProductsQuery());
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/Product/5
        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     GET /api/productos/{id}
        ///
        /// </remarks>
        /// <param name="id">El ID del producto.</param>
        /// <returns>Los detalles del producto si se encuentra.</returns>
        /// <response code="200">Retorna los detalles del producto.</response>
        /// <response code="404">Si el producto no se encuentra.</response>
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _productQueryService.Handle(new GetProductByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Product
        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        ///     POST /api/productos/create
        ///     {
        ///        "nombre": "Producto",
        ///        "descripcion": "Descripción del producto",
        ///        "precio": 100.0,
        ///        "detalles": "Detalles del producto",
        ///        "detallesDelArtesano": "Detalles del artesano",
        ///        "parametrosPersonalizacion": {
        ///          "parametros": [
        ///            {
        ///              "nombre": "Color",
        ///              "valores": [
        ///                {
        ///                  "valor": "Rojo"
        ///                }
        ///              ]
        ///            }
        ///          ],
        ///          "gravado": "Gravado personalizado"
        ///        },
        ///        "tamaño": 10.0,
        ///        "inputText": "Texto de entrada",
        ///        "gravado": "Gravado del producto",
        ///        "categoria": "Categoría del producto",
        ///        "imagen": "http://example.com/image.jpg",
        ///        "imagenesDetalle": [
        ///          {
        ///            "imagenUrl": "http://example.com/detail_image.jpg"
        ///          }
        ///        ],
        ///        "autor": "Autor del producto",
        ///        "caracteristicas": [
        ///          {
        ///            "nombre": "Material",
        ///            "valor": "Madera"
        ///          }
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="command">El comando para crear un producto.</param>
        /// <returns>El ID del producto creado si la creación es exitosa.</returns>
        /// <response code="201">Retorna el ID del producto recién creado.</response>
        /// <response code="400">Si el comando es nulo o inválido.</response>
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
