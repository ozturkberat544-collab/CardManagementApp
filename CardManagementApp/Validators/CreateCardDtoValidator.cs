using CardManagementApp.DTOs;
using FluentValidation;

namespace CardManagementApp.Validators
{
    public class CreateCardDtoValidator : AbstractValidator<CreateCardDto>
    {
        public CreateCardDtoValidator()
        {
            RuleFor(x => x.CardHolderName)
                .NotEmpty().WithMessage("Kart sahibi adı boş bırakılamaz!")
                .MinimumLength(2).WithMessage("Kart sahibi adı en az 2 karakter olmalıdır!");

            RuleFor(x => x.Limit)
                .GreaterThan(0).WithMessage("Kart limiti 0'dan büyük olmalıdır!");
        }
    }
}