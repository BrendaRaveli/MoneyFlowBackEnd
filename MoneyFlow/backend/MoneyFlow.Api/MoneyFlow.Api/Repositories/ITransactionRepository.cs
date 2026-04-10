using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId, int? month = null, int? year = null, Guid? categoryId = null, TransactionType? type = null);
    Task<Transaction?> GetByIdAsync(Guid id);
    Task AddAsync(Transaction transaction);
    void Update(Transaction transaction);
    void Delete(Transaction transaction);
    Task SaveChangesAsync();
}
