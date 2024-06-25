using Domain.Publishing.Repositories.ProductsCharacteristics;
using Domain.Publishing.Models.Entities.ProductsCharacteristics;
using Infrastructure.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Publishing.Persistence.ProductsCharacteristics;

public class ProductsCharacteristicsRepository: IProductsCharacteristicsRepository
{
    private readonly ArtisaniaDBContext _context;

    public ProductsCharacteristicsRepository(ArtisaniaDBContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync(Domain.Publishing.Models.Entities.ProductsCharacteristics.ProductsCharacteristics data)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                _context.ProductsCharacteristics.Add(data);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        return data.Id;
    }

    public async Task<List<Domain.Publishing.Models.Entities.ProductsCharacteristics.ProductsCharacteristics>> GetAllAsync()
    {
        return await _context.ProductsCharacteristics
            .Include(p => p.Colors)
            .Include(p => p.Sizes)
            .Include(p => p.Materials)
            .Include(p => p.Categories)
            .ToListAsync();
    }
}