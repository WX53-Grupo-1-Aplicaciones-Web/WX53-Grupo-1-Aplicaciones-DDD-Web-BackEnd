using Domain.Publishing.Models.Entities;

namespace Domain.Publishing.Repositories;

public interface IReceiptRepository
{
    Task<Receipt> GetByIdAsync(string id);
    Task<IEnumerable<Receipt>> GetAllAsync();
    Task AddAsync(Receipt receipt);
    Task UpdateAsync(Receipt receipt);
    Task DeleteAsync(string id);
}
