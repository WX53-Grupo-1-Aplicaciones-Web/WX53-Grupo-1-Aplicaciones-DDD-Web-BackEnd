using AutoMapper;
using Domain.Publishing.Models.Entities;
using Domain.Publishing.Models.Response;

namespace WX_53_Artisania.Middleware;

public class ModelToResponse:Profile
{
    public ModelToResponse()
    {
        CreateMap<Customer, CustomerResponse>();
    }
}