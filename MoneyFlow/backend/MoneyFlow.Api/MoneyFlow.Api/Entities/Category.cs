namespace MoneyFlow.Api.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryType Type { get; set; }
    public string UserId { get; set; } = string.Empty;
}
