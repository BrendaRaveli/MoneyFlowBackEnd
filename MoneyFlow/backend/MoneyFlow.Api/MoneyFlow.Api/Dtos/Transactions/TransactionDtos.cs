using System.ComponentModel.DataAnnotations;
using MoneyFlow.Api.Entities;

namespace MoneyFlow.Api.Dtos.Transactions;

public record CreateTransactionDto(
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MaxLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
    string Description,

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    decimal Amount,

    [Required(ErrorMessage = "O tipo é obrigatório.")]
    TransactionType Type,

    [Required(ErrorMessage = "A data é obrigatória.")]
    DateTime Date,

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    Guid CategoryId,

    [MaxLength(500, ErrorMessage = "As notas devem ter no máximo 500 caracteres.")]
    string? Notes
);

public record UpdateTransactionDto(
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MaxLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
    string Description,

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    decimal Amount,

    [Required(ErrorMessage = "A data é obrigatória.")]
    DateTime Date,

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    Guid CategoryId,

    [MaxLength(500, ErrorMessage = "As notas devem ter no máximo 500 caracteres.")]
    string? Notes
);

public record TransactionResponseDto(
    Guid Id,
    string Description,
    decimal Amount,
    TransactionType Type,
    DateTime Date,
    string? Notes,
    Guid CategoryId,
    string CategoryName,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record TransactionFilterDto(
    int? Month,
    int? Year,
    Guid? CategoryId,
    TransactionType? Type
);
