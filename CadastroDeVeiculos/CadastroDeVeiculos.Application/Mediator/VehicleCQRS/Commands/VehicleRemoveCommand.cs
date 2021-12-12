namespace CadastroDeVeiculos.Application.Mediator.VehicleCQRS.Commands
{
    public class VehicleRemoveCommand : VehicleCommand
    {
        public int Id { get; set; }

        public VehicleRemoveCommand(int id)
        {
            this.Id = id;
        }
    }
}
