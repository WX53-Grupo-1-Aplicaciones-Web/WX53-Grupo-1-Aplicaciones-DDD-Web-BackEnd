using AutoMapper;
using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Models.Commands.OrderCommands;
using Domain.Publishing.Models.Commands.ProductCommands;
using Domain.Publishing.Models.Entities;
using Domain.Publishing.Models.Entities.Orders;
using Domain.Publishing.Models.Entities.Product;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;

namespace WX_53_Artisania.Mapper;

public class ModelToRequest:Profile
{
    public ModelToRequest()
    {
        CreateMap<Customer, CreateCustomerCommand>();
        
        CreateMap<Product, CreateProductCommand>();
        CreateMap<Imagen, ImagenCommand>();
        CreateMap<Caracteristica, CaracteristicaCommand>();
        CreateMap<ParametrosPersonalizacion, ParametroPersonalizacionCommand>();
        
        CreateMap<Order,CreateOrderCommand>();
        CreateMap<OrderParameter, OrderParameterCommand>();
        CreateMap<ProductsCharacteristics, CreateProductsCharacteristicsCommand>();

    }
}