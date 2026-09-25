using CardManagementApp.DTOs;
using CardManagementApp.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace CardManagementApp.Tests
{
    public class CreateCardDtoValidatorTests
    {
        private readonly CreateCardDtoValidator _validator;

        public CreateCardDtoValidatorTests()
        {
            //Testlerde kullanacağımız validator nesnesini hazırlıyoruz
            _validator = new CreateCardDtoValidator();
        }
        [Fact]
        public void Should_Have_Error_When_CardHolderName_Is_Empty()
        {
            //ARRANGE (Hazırlık) - İsim alanı boş bir DTO oluşturuyoruz
            var model = new CreateCardDto { CardHolderName = "", Limit = 5000 };
            //ACT (Eyleme Geçme) - Validator'ı çalıştırıyoruz
            var result = _validator.TestValidate(model);
            //ASSERT (Doğrulama) - CardHolderName alanı için hata fırlatıldığını doğruluyoruz
            result.ShouldHaveValidationErrorFor(c => c.CardHolderName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Model_Is_Valid()
        {
            //ARRANGE (Hazırlık) - Her şeyi kuralına uygun düzgün veriyoruz
            var model = new CreateCardDto { CardHolderName = "Berat Öztürk", Limit = 5000 };

            //ACT (Eyleme Geçme)
            var result = _validator.TestValidate(model);

            //ASSERT (Doğrulama) - Hiçbir alan için hata fırlatılmadığını doğruluyoruz
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
