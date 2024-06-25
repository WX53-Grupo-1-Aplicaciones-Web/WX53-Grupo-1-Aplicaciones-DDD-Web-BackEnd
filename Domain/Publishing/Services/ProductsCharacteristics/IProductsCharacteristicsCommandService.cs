using Domain.Publishing.Models.Commands.CustomerCommands;

namespace Domain.Publishing.Services.ProductsCharacteristics;

public interface IProductsCharacteristicsCommandService
{
    Task<int> Handle(CreateProductsCharacteristicsCommand command);
}