using CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Business.NotificationHandlers;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private NotificationContext _notification;

        public UserRemoveCommandHandler(IUserRepository userRepository, NotificationContext notification)
        {
            this._userRepository = userRepository;
            this._notification = notification;
        }

        public async Task<User> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                this._notification.AddNotification("User", Message.NotFound.Description());
            }

            var result = await this._userRepository.DeleteAsync(user.Id);
            return result;
        }
    }
}
