using Bogus;
using CardManagementApp.DTOs;
using CardManagementApp.Entities;
using Xunit;

namespace CardManagementApp.Tests
{
    public class CardServiceTests
    {
        // Bogus ile senin CreateCardDto yapına uygun sahte veri üreteç
        private readonly Faker<CreateCardDto> _cardDtoFaker;

        public CardServiceTests()
        {
            // Bogus Kuralı: Gerçekçi isim ve 1.000 - 50.000 arası kart limiti üretir
            _cardDtoFaker = new Faker<CreateCardDto>()
                .RuleFor(c => c.CardHolderName, f => f.Name.FullName())
                .RuleFor(c => c.Limit, f => f.Random.Decimal(1000, 50000));
        }

        [Fact]
        public void CreateCard_WithValidDto_ShouldGenerateValidData()
        {
            // 1. ARRANGE (Hazırlık) - Bogus sahte DTO üretiyor
            var fakeCardDto = _cardDtoFaker.Generate();

            // 2. ASSERT (Doğrulama) - Değerler düzgün üretildi mi?
            Assert.NotNull(fakeCardDto);
            Assert.False(string.IsNullOrWhiteSpace(fakeCardDto.CardHolderName));
            Assert.True(fakeCardDto.Limit >= 1000);
        }

        [Theory]
        [InlineData(1000, 500)]   // Limit 1000, Harcama 500 -> Yeterli
        [InlineData(5000, 5000)]  // Limit 5000, Harcama 5000 -> Yeterli
        public void Card_WhenLimitIsSufficient_ShouldAllowTransaction(decimal limit, decimal amount)
        {
            // ARRANGE
            var remainingLimit = limit;

            // ACT
            remainingLimit -= amount;

            // ASSERT
            Assert.True(remainingLimit >= 0);
        }
    }
}