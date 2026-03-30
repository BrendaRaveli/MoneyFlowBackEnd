using MoneyFlow.Api.Dtos.Categories;

namespace MoneyFlow.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
    Task<CategoryResponseDto?> GetByIdAsync(int id);
    Task<CategoryResponseDto> CreateAsync(CreateCategoryDto createDto);
    Task<CategoryResponseDto> UpdateAsync(int id, UpdateCategoryDto updateDto); 
    Task DeleteAsync(int id);
}
