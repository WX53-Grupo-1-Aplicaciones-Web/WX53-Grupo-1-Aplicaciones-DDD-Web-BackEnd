using Domain.Publishing.Models.Queries.ProductsCharacteristicsQueries;
using Domain.Publishing.Models.Response.ProductsCharacteristics;

namespace Domain.Publishing.Services.ProductsCharacteristics;

public interface IProductsCharacteristicsQueryService
{
    Task<List<ProductsCharacteristicsResponse>?> Handle(GetAllProductsCharacteristicsQuery query);
}