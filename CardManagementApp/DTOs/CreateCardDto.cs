namespace CardManagementApp.DTOs;

public class CreateCardDto
{
    public string CardHolderName { get; set; } = string.Empty;
    public decimal Limit { get; set; }
}