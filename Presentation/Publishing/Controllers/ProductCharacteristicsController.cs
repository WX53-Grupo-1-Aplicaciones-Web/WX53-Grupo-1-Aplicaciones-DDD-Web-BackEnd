using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Publishing.Models.Queries.ProductsCharacteristicsQueries;
using Domain.Publishing.Repositories.ProductsCharacteristics;
using Domain.Publishing.Services.ProductsCharacteristics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX_53_Artisania.Publishing.Controllers
{
    [Route("api/product-characteristics")]
    [ApiController]
    public class ProductCharacteristicsController : ControllerBase
    {
        private readonly IProductsCharacteristicsQueryService _productsCharacteristicsQueryService;
        private readonly IMapper _mapper;
        private     readonly IProductsCharacteristicsRepository _productsCharacteristicsRepository;

        public ProductCharacteristicsController(IProductsCharacteristicsQueryService productsCharacteristicsQueryService, IProductsCharacteristicsRepository productsCharacteristicsRepository,  IMapper mapper)
        {
            _productsCharacteristicsQueryService = productsCharacteristicsQueryService;
            _mapper = mapper;
            _productsCharacteristicsRepository = productsCharacteristicsRepository;


        }

        // GET: api/ProductCharacteristics
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _productsCharacteristicsRepository.GetAllAsync();

            if (data == null || data.Count == 0) return NotFound();

            var result = data.Select(pc => new
            {
                color = pc.Colors.Select(c => c.Name).ToList(),
                tamanio = pc.Sizes.Select(s => s.Name).ToList(),
                material = pc.Materials.Select(m => m.Name).ToList(),
                categoria = pc.Categories.Select(c => c.Name).ToList()
            }).ToList();

            return Ok(new { productos_caracteristicas = result });
        }

    }
}
