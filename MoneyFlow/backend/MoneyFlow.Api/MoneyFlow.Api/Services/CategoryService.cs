using MoneyFlow.Api.Dtos.Categories;
using MoneyFlow.Api.Entities;
using MoneyFlow.Api.Repositories;
using MoneyFlow.Api.Exceptions;

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
        return categories.Select(c => MapToResponseDto(c));
    }

    public async Task<CategoryResponseDto> GetByIdAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        
        if (category == null)
            throw new NotFoundException("Categoria não encontrada.");

        return MapToResponseDto(category);
    }

    public async Task<CategoryResponseDto> CreateAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Type = dto.Type,
            UserId = "user-123" // Placeholder para futura implementação de Auth
        };

        await _repository.CreateAsync(category);

        return MapToResponseDto(category);
    }

    public async Task<CategoryResponseDto> UpdateAsync(Guid id, CategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            throw new NotFoundException("Categoria não encontrada.");

        category.Name = dto.Name;
        category.Type = dto.Type;

        await _repository.UpdateAsync(category);

        return MapToResponseDto(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            throw new NotFoundException("Categoria não encontrada.");

        await _repository.DeleteAsync(id);
    }

    private static CategoryResponseDto MapToResponseDto(Category category)
    {
        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Type = category.Type
        };
    }
}
