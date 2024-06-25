using Domain.Publishing.Models.Entities;
using Domain.Publishing.Repositories;
using Infrastructure.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Publishing.Persistence;

public class ReceiptRepository : IReceiptRepository
{
    private readonly ArtisaniaDBContext _context;

    public ReceiptRepository(ArtisaniaDBContext context)
    {
        _context = context;
    }

    public async Task<Receipt> GetByIdAsync(string id)
    {
        return await _context.Receipts.FindAsync(id);
    }
    
    public async Task<IEnumerable<Receipt>> GetAllAsync()
    {
        return await _context.Receipts.ToListAsync();
    }

    public async Task AddAsync(Receipt receipt)
    {
        await _context.Receipts.AddAsync(receipt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Receipt receipt)
    {
        _context.Receipts.Update(receipt);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var receipt = await _context.Receipts.FindAsync(id);
        if (receipt != null)
        {
            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
        }
    }
}
