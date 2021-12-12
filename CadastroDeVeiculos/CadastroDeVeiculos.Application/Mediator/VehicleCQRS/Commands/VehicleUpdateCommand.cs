namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands
{
    public class VehicleUpdateCommand : VehicleCommand
    {
        public int Id { get; set; }

        public VehicleUpdateCommand(int id)
        {
            this.Id = id;
        }

    }
}
