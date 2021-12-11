namespace CadastroDeVeiculos.Application.Mediator.ClientCQRS.Commands
{
    public class ClientRemoveCommand : ClientCommand
    {
        public int Id { get; set; }

        public ClientRemoveCommand(int id)
        {
            this.Id = id;
        }
    }
}
