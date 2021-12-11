namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands
{
    public class UserUpdateCommand : UserCommand
    {
        public int Id { get; set; }
    }
}
