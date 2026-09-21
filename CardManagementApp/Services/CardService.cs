using CardManagementApp.Context;
using CardManagementApp.DTOs;
using CardManagementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardManagementApp.Services
{
    public class CardService
    {
        private readonly AppDbContext _context;

        public CardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Card> CreateCard(CreateCardDto dto)
        {
            var card = new Card
            {
                CardNumber = Random.Shared.NextInt64(1000000000000000, 9999999999999999).ToString(),
                CardHolderName = dto.CardHolderName,
                Limit = dto.Limit,
                Balance = 0,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<List<Card>> GetAllCards()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Transaction?> MakeTransaction(CreateTransactionDto dto)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == dto.CardId);
            if (card == null) return null;

            if (card.Balance + dto.Amount > card.Limit)
                throw new Exception("Yetersiz limit!");

            card.Balance += dto.Amount;

            var transaction = new Transaction
            {
                CardId = dto.CardId,
                Amount = dto.Amount,
                Description = dto.Description,
                TransactionDate = DateTime.UtcNow
            };

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Card?> PayDebt(PayDebtDto dto)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == dto.CardId);
            if (card == null) return null;

            card.Balance -= dto.Amount;
            if (card.Balance < 0) card.Balance = 0;

            await _context.SaveChangesAsync();
            return card;
        }
    }
}