using MyFinance.Domain.Enums;

namespace MyFinance.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public TransactionType Type { get; set; }
    public List<Transaction>? Transactions { get; set; }
}
