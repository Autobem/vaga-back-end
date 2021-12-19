using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeVeiculos.Domain.ValueObject
{
    public abstract class BaseValueObject
    {
        [NotMapped]
        public  bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TValueObject>(TValueObject valueObject, AbstractValidator<TValueObject> validator)
        {
            ValidationResult = validator.Validate(valueObject);
            return Valid = ValidationResult.IsValid;
        }

    }
}
