using CadastroDeVeiculos.Domain.Validations;
using CadastroDeVeiculos.Domain.ValueObject;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Domain.Entities
{
    public sealed class Client : BaseEntity
    {
        public Name Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }


        public ICollection<Vehicle> Vehicles { get; set; }

        public Client(Name name, string phoneNumber, string email, string document)
        {
            
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Document = document;

            Validate(this, new ClientValidation());
        }

        public void UpdateClient(Name name, string phoneNumber, string email, string document)
        {
            
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Document = document;

            Validate(this, new ClientValidation());
        }
    }
}
