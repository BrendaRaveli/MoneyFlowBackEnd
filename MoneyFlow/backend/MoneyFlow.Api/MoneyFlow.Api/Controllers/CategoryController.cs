using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Api.Dtos.Categories;
using MoneyFlow.Api.Services;

namespace MoneyFlow.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
    {
        var categories = await _service.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
    {
        if (id <= 0) return BadRequest("O ID deve ser maior que zero.");

        var category = await _service.GetByIdAsync(id);

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> Create(CreateCategoryDto createDto)
    {
        var category = await _service.CreateAsync(createDto);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> Update(int id, UpdateCategoryDto updateDto)
    {
        if (id <= 0) return BadRequest("O ID deve ser maior que zero.");

        var category = await _service.UpdateAsync(id, updateDto);
        
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return BadRequest("O ID deve ser maior que zero.");

        await _service.DeleteAsync(id);
        
        return NoContent();
    }
}
