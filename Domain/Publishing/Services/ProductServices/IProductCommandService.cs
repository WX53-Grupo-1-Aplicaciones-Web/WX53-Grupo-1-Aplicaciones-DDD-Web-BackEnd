using Domain.Publishing.Models.Commands.ProductCommands;
using Domain.Publishing.Models.Entities.Product;

namespace Domain.Publishing.Services.ProductServices;

public interface IProductCommandService
{
    Task<int> Handle(CreateProductCommand command);
    Task<bool> Handle(DeleteProductCommand command); 
    Task<bool> Handle(int id, UpdateProductCommand command);
    
}