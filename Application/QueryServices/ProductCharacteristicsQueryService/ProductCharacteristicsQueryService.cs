using AutoMapper;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;
using Domain.Publishing.Models.Queries.ProductsCharacteristicsQueries;
using Domain.Publishing.Models.Response.ProductsCharacteristics;
using Domain.Publishing.Repositories.ProductsCharacteristics;
using Domain.Publishing.Services.ProductsCharacteristics;

namespace Application.QueryServices.ProductCharacteristicsQueryService;

public class ProductCharacteristicsQueryService:IProductsCharacteristicsQueryService
{
    private readonly IProductsCharacteristicsRepository _productsCharacteristicsRepository;
    private readonly IMapper _mapper;

    public ProductCharacteristicsQueryService(IProductsCharacteristicsRepository productsCharacteristicsRepository, IMapper mapper)
    {
        _productsCharacteristicsRepository = productsCharacteristicsRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ProductsCharacteristicsResponse>?> Handle(GetAllProductsCharacteristicsQuery query)
    {
        var data = await _productsCharacteristicsRepository.GetAllAsync();
        var result = _mapper.Map<List<ProductsCharacteristics>, List<ProductsCharacteristicsResponse>>(data);
        return result;
    }
}