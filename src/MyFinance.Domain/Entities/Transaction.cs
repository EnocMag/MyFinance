using MyFinance.Domain.Enums;

namespace MyFinance.Domain.Entities;

public class Transaction : BaseEntity
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public string? Description { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
