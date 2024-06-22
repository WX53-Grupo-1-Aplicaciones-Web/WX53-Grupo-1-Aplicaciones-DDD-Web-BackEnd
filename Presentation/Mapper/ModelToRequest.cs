using AutoMapper;
using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Models.Entities;

namespace WX_53_Artisania.Mapper;

public class ModelToRequest:Profile
{
    public ModelToRequest()
    {
        CreateMap<Customer, CreateCustomerCommand>();
    }
}