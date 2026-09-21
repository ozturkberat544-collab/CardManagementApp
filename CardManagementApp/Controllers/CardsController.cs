using CardManagementApp.DTOs;
using CardManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardManagementApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardDto dto)
        {
            var card = await _cardService.CreateCard(dto);
            return Ok(card);
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> MakeTransaction([FromBody] CreateTransactionDto dto)
        {
            try
            {
                var transaction = await _cardService.MakeTransaction(dto);
                if (transaction == null)
                    return NotFound("Kart bulunamadı.");

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("pay-debt")]
        public async Task<IActionResult> PayDebt([FromBody] PayDebtDto dto)
        {
            var card = await _cardService.PayDebt(dto);
            if (card == null)
                return NotFound("Kart bulunamadı.");

            return Ok(card);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _cardService.GetAllCards();
            return Ok(cards);
        }
    }
}