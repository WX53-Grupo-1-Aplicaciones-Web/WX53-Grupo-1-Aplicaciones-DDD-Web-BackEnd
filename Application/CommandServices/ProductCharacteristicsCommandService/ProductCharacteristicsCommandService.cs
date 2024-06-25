using AutoMapper;
using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Repositories.ProductsCharacteristics;
using Domain.Publishing.Services.ProductsCharacteristics;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;

namespace Application.CommandServices.ProductCharacteristicsCommandService;

public class ProductCharacteristicsCommandService: IProductsCharacteristicsCommandService
{
    private readonly IProductsCharacteristicsRepository _productsCharacteristicsRepository;
    private readonly IMapper _mapper;
    
    public async Task<int> Handle(CreateProductsCharacteristicsCommand command)
    {
        var existingProductCharacteristics = await _productsCharacteristicsRepository.GetAllAsync();

        var productCharacteristics = _mapper.Map<CreateProductsCharacteristicsCommand, ProductsCharacteristics>(command);
        return await _productsCharacteristicsRepository.SaveAsync(productCharacteristics);
    }
}