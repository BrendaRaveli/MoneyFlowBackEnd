using Microsoft.EntityFrameworkCore;
using MoneyFlow.Api.Data;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MoneyFlowDbContext _context;

    public CategoryRepository(MoneyFlowDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
    return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
