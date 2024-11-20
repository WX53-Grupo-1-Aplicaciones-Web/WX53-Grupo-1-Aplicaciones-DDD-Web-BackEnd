using Domain.Publishing.Models.Commands.CustomerCommands;
using Domain.Publishing.Models.Entities;

namespace Domain.Publishing.Services;

public interface ICustomerCommandService
{
    Task<int> Handle(CreateCustomerCommand command);
    Task<bool> Handle(int id, UpdateCustomerCommand command);
    Task<bool> Handle(UpdateCustomerPasswordCommand command);
    
    Task<String> Handle(SignInCommand command);
    Task<Customer> Handle(SignUpCommand command);

}
