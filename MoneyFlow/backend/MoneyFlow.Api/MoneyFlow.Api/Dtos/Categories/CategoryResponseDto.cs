using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Dtos.Categories;

public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryType Type { get; set; }
}
