using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using FluentValidation;

namespace CadastroDeVeiculos.Domain.Validations
{
    public class VehicleValidation : AbstractValidator<Vehicle>
    {
        public VehicleValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(v => v.ModelName).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(v => v.ModelName).Length(2, 50)
                .WithMessage(Message.MoreExpected.Description().FormatMessage("Modelo", "2 a 50"));

            RuleFor(v => v.Brand).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(v => v.Brand).Length(2, 70)
                .WithMessage(Message.MoreExpected.Description().FormatMessage("Fabricante", "2 a 70"));

            RuleFor(v => v.YearOfManufacturer).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(v => v.YearOfManufacturer).NotEqual(0)
                .WithMessage(Message.PriceExpected.Description().FormatMessage("Ano de fabricação", "0"));

            RuleFor(v => v.Plate).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(v => v.Plate).Length(7).WithMessage("Placa deve ter 7 caracteres");

        }

    }
}
