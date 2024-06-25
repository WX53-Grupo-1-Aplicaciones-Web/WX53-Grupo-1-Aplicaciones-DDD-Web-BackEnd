namespace Domain.Publishing.Repositories.ProductsCharacteristics;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;
public interface IProductsCharacteristicsRepository
{
    Task<int> SaveAsync(ProductsCharacteristics data);
    Task<List<ProductsCharacteristics>> GetAllAsync();
}