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
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez").MinimumLength(5).WithMessage("En az 5 karakter giriniz");
            RuleFor(x=> x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez");
            RuleFor(x=> x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x=> x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez");
            RuleFor(x=> x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
    }
}
