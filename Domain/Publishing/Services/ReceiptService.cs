using Domain.Publishing.Models.Commands.ReceiptCommands;
using Domain.Publishing.Models.Entities;
using Domain.Publishing.Repositories;

namespace Domain.Publishing.Services;

public class ReceiptService
{
    private readonly IReceiptRepository _receiptRepository;

    public ReceiptService(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<Receipt> GetReceiptByIdAsync(string id)
    {
        return await _receiptRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Receipt>> GetAllReceiptAsync()
    {
        return await _receiptRepository.GetAllAsync();
    }

    public async Task AddReceiptAsync(CreateReceiptCommand command)
    {
        var receipt = new Receipt
        {
            Id = Guid.NewGuid().ToString(),
            ProductId = command.ProductId,
            Product = command.Product,
            //Parameters = command.Parameters,
            Price = command.Price
        };
        await _receiptRepository.AddAsync(receipt);
    }

    public async Task UpdateReceiptAsync(UpdateReceiptCommand command)
    {
        var receipt = await _receiptRepository.GetByIdAsync(command.Id);
        if (receipt != null)
        {
            receipt.ProductId = command.ProductId;
            receipt.Product = command.Product;
            //receipt.Parameters = command.Parameters;
            receipt.Price = command.Price;
            await _receiptRepository.UpdateAsync(receipt);
        }
    }

    public async Task DeleteReceiptAsync(string id)
    {
        await _receiptRepository.DeleteAsync(id);
    }
}
