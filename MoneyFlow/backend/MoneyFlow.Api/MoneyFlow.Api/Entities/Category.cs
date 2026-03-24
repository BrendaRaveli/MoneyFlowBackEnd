namespace MoneyFlow.Api.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = "default-icon";
    public string Color { get; set; } = "#000000";
}
