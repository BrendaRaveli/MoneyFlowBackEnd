using Moq;
using MoneyFlow.Api.Services;
using MoneyFlow.Api.Repositories;
using MoneyFlow.Api.Entities;
using MoneyFlow.Api.Dtos.Categories;
using MoneyFlow.Api.Exceptions;

namespace MoneyFlow.Tests;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _repositoryMock;
    private readonly CategoryService _service;

    public CategoryServiceTests()
    {
        // Criamos o "dublê" (Mock) do repositório
        _repositoryMock = new Mock<ICategoryRepository>();
        
        // Injetamos o mock no serviço real
        _service = new CategoryService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnCategories()
    {
        // Arrange (Organizar)
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Food", Type = "Expense" },
            new Category { Id = 2, Name = "Salary", Type = "Income" }
        };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

        // Act (Agir)
        var result = await _service.GetAllAsync();

        // Assert (Afirmar)
        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Name == "Food");
    }

    [Fact]
    public async Task GetByIdAsync_WhenCategoryExists_ShouldReturnCategory()
    {
        // Arrange
        var category = new Category { Id = 1, Name = "Food", Type = "Expense" };
        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(category);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Food", result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_WhenCategoryDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Category?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(99));
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedCategory()
    {
        // Arrange
        var dto = new CreateCategoryDto { Name = "Transport", Type = "Expense" };
        
        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        Assert.Equal("Transport", result.Name);
        _repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WhenCategoryExists_ShouldUpdateAndReturnCategory()
    {
        // Arrange
        var existingCategory = new Category { Id = 1, Name = "Food", Type = "Expense" };
        var updateDto = new UpdateCategoryDto { Name = "Groceries", Type = "Expense" };
        
        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);

        // Act
        var result = await _service.UpdateAsync(1, updateDto);

        // Assert
        Assert.Equal("Groceries", result.Name);
        _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WhenCategoryExists_ShouldCallRepositoryDelete()
    {
        // Arrange
        var existingCategory = new Category { Id = 1, Name = "Food", Type = "Expense" };
        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingCategory);

        // Act
        await _service.DeleteAsync(1);

        // Assert
        _repositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
    }
}
