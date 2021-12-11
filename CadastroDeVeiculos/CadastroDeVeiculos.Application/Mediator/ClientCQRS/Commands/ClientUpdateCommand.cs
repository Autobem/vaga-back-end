namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands
{
    public class ClientUpdateCommand : ClientCommand
    {
        public int Id { get; set; }

        public ClientUpdateCommand(int id)
        {
            this.Id = id;
        }
    }
}
