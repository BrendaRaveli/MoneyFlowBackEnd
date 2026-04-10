using MoneyFlow.Api.Dtos.Transactions;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Services;

public interface ITransactionService
{
    Task<IEnumerable<TransactionResponseDto>> GetAllAsync(Guid userId, TransactionFilterDto filter);
    Task<TransactionResponseDto> GetByIdAsync(Guid id);
    Task<TransactionResponseDto> CreateAsync(Guid userId, CreateTransactionDto dto);
    Task<TransactionResponseDto> UpdateAsync(Guid id, UpdateTransactionDto dto);
    Task DeleteAsync(Guid id);
}
