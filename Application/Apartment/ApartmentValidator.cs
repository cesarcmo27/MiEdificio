using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Apartment
{
    public class ApartmentValidator : AbstractValidator<ApartmentDTO>
    {

        public ApartmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del departamento no puede estar vacio");
            RuleFor(x => x.Percentage).NotEmpty().WithMessage("El porcentaje no puede estar vacio")
            //.Must(percentage => ).WithMessage("numero invalido")
            //.Custom(ValidateNumber)
            .InclusiveBetween(0, 100).WithMessage("no esta en rango");
            RuleFor(x => x.Status).NotEmpty().WithMessage("El estado no puede estar vacio")
                                  .InclusiveBetween(1, 2).WithMessage("no esta en rango");


        }

        private bool ValidateNumber(string number)
        {
            double numberConverted = 0;
            return double.TryParse(number, out numberConverted);
        }   
    }
}
