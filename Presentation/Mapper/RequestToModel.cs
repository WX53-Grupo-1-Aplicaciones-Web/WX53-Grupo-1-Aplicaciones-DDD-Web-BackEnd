using AutoMapper;
using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Models.Entities;

namespace WX_53_Artisania.Mapper;

public class RequestToModel:Profile
{
    public RequestToModel()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerPasswordCommand, Customer>();
    }
    
}