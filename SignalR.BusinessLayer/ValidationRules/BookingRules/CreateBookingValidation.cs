using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingRules
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x=> x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez");
            RuleFor(x=> x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x=> x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez");
            RuleFor(x=> x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim alanına en az 5 karakter veri giriniz")
                .MaximumLength(50).WithMessage("İsim alanına en fazla 50 karakter veri giriniz");

            RuleFor(x => x.Name).MaximumLength(500).WithMessage("Açıklama alanına en fazla 500 karakter veri giriniz");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
    }
}
