using System.ComponentModel.DataAnnotations;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Dtos.Categories;

public class CategoryDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O tipo é obrigatório.")]
    public CategoryType Type { get; set; }
}
