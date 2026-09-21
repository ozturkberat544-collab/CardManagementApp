namespace CardManagementApp.DTOs;

public class CreateTransactionDto
{
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
}