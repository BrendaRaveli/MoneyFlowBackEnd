using MoneyFlow.Api.Dtos.Categories;

namespace MoneyFlow.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
    Task<CategoryResponseDto> GetByIdAsync(Guid id);
    Task<CategoryResponseDto> CreateAsync(CategoryDto dto);
    Task<CategoryResponseDto> UpdateAsync(Guid id, CategoryDto dto);
    Task DeleteAsync(Guid id);
}
