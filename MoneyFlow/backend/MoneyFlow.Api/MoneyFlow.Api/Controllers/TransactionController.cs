using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Api.Dtos.Transactions;
using MoneyFlow.Api.Services;

namespace MoneyFlow.Api.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionController(ITransactionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionResponseDto>>> GetAll([FromQuery] TransactionFilterDto filter)
    {
        // Placeholder UserId até implementar JWT
        var userId = Guid.Parse("user-123"); 
        var transactions = await _service.GetAllAsync(userId, filter);
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionResponseDto>> GetById(Guid id)
    {
        var transaction = await _service.GetByIdAsync(id);
        return Ok(transaction);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionResponseDto>> Create(CreateTransactionDto dto)
    {
        // Placeholder UserId até implementar JWT
        var userId = Guid.Parse("user-123");
        var transaction = await _service.CreateAsync(userId, dto);
        return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TransactionResponseDto>> Update(Guid id, UpdateTransactionDto dto)
    {
        var transaction = await _service.UpdateAsync(id, dto);
        return Ok(transaction);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
