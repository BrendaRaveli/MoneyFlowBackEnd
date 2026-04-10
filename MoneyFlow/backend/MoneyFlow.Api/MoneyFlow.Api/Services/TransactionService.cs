using MoneyFlow.Api.Dtos.Transactions;
using MoneyFlow.Api.Entities;
using MoneyFlow.Api.Exceptions;
using MoneyFlow.Api.Repositories;

namespace MoneyFlow.Api.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly ICategoryRepository _categoryRepository;

    public TransactionService(ITransactionRepository repository, ICategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync(Guid userId, TransactionFilterDto filter)
    {
        var transactions = await _repository.GetAllByUserAsync(
            userId, 
            filter.Month, 
            filter.Year, 
            filter.CategoryId, 
            filter.Type
        );

        return transactions.Select(t => MapToResponse(t));
    }

    public async Task<TransactionResponseDto> GetByIdAsync(Guid id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        
        if (transaction == null)
            throw new NotFoundException("Lançamento não encontrado.");

        return MapToResponse(transaction);
    }

    public async Task<TransactionResponseDto> CreateAsync(Guid userId, CreateTransactionDto dto)
    {
        if (dto.Amount <= 0)
            throw new ArgumentException("O valor deve ser maior que zero.");

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        
        if (category == null)
            throw new NotFoundException("Categoria não encontrada.");

        // Validação de tipo: se a categoria for Expense, a transação deve ser Expense
        if ((int)category.Type != (int)dto.Type)
            throw new ArgumentException("O tipo da transação deve corresponder ao tipo da categoria.");

        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = dto.Description,
            Amount = dto.Amount,
            Type = dto.Type,
            Date = dto.Date,
            Notes = dto.Notes,
            UserId = userId,
            CategoryId = dto.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(transaction);
        await _repository.SaveChangesAsync();

        // Recarrega para incluir os dados da categoria no retorno
        var createdTransaction = await _repository.GetByIdAsync(transaction.Id);
        return MapToResponse(createdTransaction!);
    }

    public async Task<TransactionResponseDto> UpdateAsync(Guid id, UpdateTransactionDto dto)
    {
        if (dto.Amount <= 0)
            throw new ArgumentException("O valor deve ser maior que zero.");

        var transaction = await _repository.GetByIdAsync(id);
        
        if (transaction == null)
            throw new NotFoundException("Lançamento não encontrado.");

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        
        if (category == null)
            throw new NotFoundException("Categoria não encontrada.");

        // Validação de tipo imutável: o tipo da transação original deve bater com o tipo da nova categoria
        if ((int)category.Type != (int)transaction.Type)
            throw new ArgumentException("A nova categoria deve ter o mesmo tipo da transação original.");

        transaction.Description = dto.Description;
        transaction.Amount = dto.Amount;
        transaction.Date = dto.Date;
        transaction.CategoryId = dto.CategoryId;
        transaction.Notes = dto.Notes;
        transaction.UpdatedAt = DateTime.UtcNow;

        _repository.Update(transaction);
        await _repository.SaveChangesAsync();

        return MapToResponse(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        
        if (transaction == null)
            throw new NotFoundException("Lançamento não encontrado.");

        _repository.Delete(transaction);
        await _repository.SaveChangesAsync();
    }

    private static TransactionResponseDto MapToResponse(Transaction t)
    {
        return new TransactionResponseDto(
            t.Id,
            t.Description,
            t.Amount,
            t.Type,
            t.Date,
            t.Notes,
            t.CategoryId,
            t.Category?.Name ?? "Sem Categoria",
            t.CreatedAt,
            t.UpdatedAt
        );
    }
}
