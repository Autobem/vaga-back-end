using CadastroDeVeiculos.Domain.Validations;

namespace CadastroDeVeiculos.Domain.Entities
{
    public sealed class Vehicle : BaseEntity
    {
        public string ModelName { get; private set; }
        public string Manufacturer { get; private set; }
        public int YearOfManufacturer { get; private set; }
        public string PlateTheVehicle { get; private set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }


        public Vehicle(string modelName, string manufacture, int yearOfManufacturer, string plateOfVehicle)
        {
            Validate(this, new VehicleValidation());

            this.ModelName = modelName;
            this.Manufacturer = manufacture;
            this.YearOfManufacturer = yearOfManufacturer;
            this.PlateTheVehicle = plateOfVehicle;
        }

        public void UpdateVehicle(string modelName, string manufacture, int yearOfManufacturer, string plateOfVehicle)
        {
            Validate(this, new VehicleValidation());

            this.ModelName = modelName;
            this.Manufacturer = manufacture;
            this.YearOfManufacturer = yearOfManufacturer;
            this.PlateTheVehicle = plateOfVehicle;
        }

    }
}
