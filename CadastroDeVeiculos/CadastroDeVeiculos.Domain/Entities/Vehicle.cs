using CadastroDeVeiculos.Domain.Validations;

namespace CadastroDeVeiculos.Domain.Entities
{
    public sealed class Vehicle : BaseEntity
    {
        public string ModelName { get; private set; }
        public string Brand { get; private set; }
        public int YearOfManufacturer { get; private set; }
        public string Plate { get; private set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }


        public Vehicle(string modelName, string brand, int yearOfManufacturer, string plate)
        {
           

            this.ModelName = modelName;
            this.Brand = brand;
            this.YearOfManufacturer = yearOfManufacturer;
            this.Plate = plate;

            Validate(this, new VehicleValidation());
        }

        public void UpdateVehicle(string modelName, string brand, int yearOfManufacturer, string plate)
        {
            
            this.ModelName = modelName;
            this.Brand = brand;
            this.YearOfManufacturer = yearOfManufacturer;
            this.Plate = plate;

            Validate(this, new VehicleValidation());
        }

    }
}
