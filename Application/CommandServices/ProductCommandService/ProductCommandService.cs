using AutoMapper;
using Domain.Publishing.Models.Commands.ProductCommands;
using Domain.Publishing.Models.Entities.Product;
using Domain.Publishing.Repositories;
using Domain.Publishing.Services.ProductServices;

namespace Application.CommandServices.ProductCommandService;

public class ProductCommandService:IProductCommandService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductCommandService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateProductCommand command)
    {
        var Product = _mapper.Map<CreateProductCommand, Product>(command);
        return await _productRepository.SaveAsync(Product);
    }
}