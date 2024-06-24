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

    public OrderCommandService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateOrderCommand command)
    {
        var order = _mapper.Map<CreateOrderCommand, Order>(command);
        return await _orderRepository.SaveAsync(order);
    }
    
    
}