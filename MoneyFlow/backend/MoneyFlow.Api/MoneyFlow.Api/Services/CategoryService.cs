using MoneyFlow.Api.Dtos.Categories;
using MoneyFlow.Api.Entities;
using MoneyFlow.Api.Repositories;

namespace MoneyFlow.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return categories.Select(c => new CategoryResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            Type = c.Type
        });
    }

    public async Task<CategoryResponseDto?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return null;

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Type = category.Type
        };
    }

    public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto createDto)
    {
        var category = new Category
        {
            Name = createDto.Name,
            Type = createDto.Type
        };

        await _repository.CreateAsync(category);

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Type = category.Type
        };
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto updateDto)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category != null)
        {
            category.Name = updateDto.Name;
            category.Type = updateDto.Type;
            await _repository.UpdateAsync(category);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
