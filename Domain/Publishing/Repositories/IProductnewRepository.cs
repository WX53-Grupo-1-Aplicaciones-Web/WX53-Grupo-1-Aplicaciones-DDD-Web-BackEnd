using Domain.Publishing.Models.Entities.Productnew;

namespace Domain.Publishing.Repositories;

public interface IProductnewRepository
{
    Task<int> SaveAsync(Productnew productnew);
    Task<List<Productnew>> GetAllAsync();
    Task<Productnew> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Productnew productnew);
    Task<bool> UpdatePriceAsync(decimal price, int id);
    Task<bool> DeleteAsync(int id);
}