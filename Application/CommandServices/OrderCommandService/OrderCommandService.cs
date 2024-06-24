using AutoMapper;
using Domain.Publishing.Models.Commands.OrderCommands;
using Domain.Publishing.Models.Commands.ProductCommands;
using Domain.Publishing.Models.Entities.Orders;
using Domain.Publishing.Models.Entities.Product;
using Domain.Publishing.Repositories;
using Domain.Publishing.Services.OrderServices;

namespace Application.CommandServices.OrderCommandService;

public class OrderCommandService:IOrderCommandService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;


    public OrderCommandService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _productRepository = productRepository;

    }
    
    public async Task<int> Handle(CreateOrderCommand command)
    {
        int productId;
        if (int.TryParse(command.ProductId, out productId))
        {
            var product = await _productRepository.GetByIdAsync(productId);
        }
        else
        {
        }
        
        // REGLA DE NEGOCIO:
        // Aumentamos el precio del producto en un 0.3% por cada vez que ha sido ordenado.
        // Esto se hace para incentivar la diversificación de los productos que se compran y evitar que siempre se compren los mismos productos.
        var orderCount = await _orderRepository.GetOrderCountForProduct(command.ProductId);

        command.Price += command.Price * 0.003m * orderCount;

        var order = _mapper.Map<CreateOrderCommand, Order>(command);
        return await _orderRepository.SaveAsync(order);
    }
    
    
}