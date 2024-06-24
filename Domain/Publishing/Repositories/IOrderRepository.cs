using Domain.Publishing.Models.Entities.Orders;

namespace Domain.Publishing.Repositories;

public interface IOrderRepository
{
    Task<int> SaveAsync(Order data);
    Task<List<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);

}