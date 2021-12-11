using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeVeiculos.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }

        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            ValidationResult = validator.Validate(entity);
            return Valid = ValidationResult.IsValid;
        }
    }
}
