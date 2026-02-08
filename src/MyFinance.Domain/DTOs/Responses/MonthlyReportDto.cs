namespace MyFinance.Domain.DTOs.Responses;

public class MonthlyReportDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Total { get; set; }
}
