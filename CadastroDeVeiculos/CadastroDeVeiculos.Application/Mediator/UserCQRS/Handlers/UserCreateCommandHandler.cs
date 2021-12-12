using CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;

        public UserCreateCommandHandler(IUserRepository userRepository, INotificationContext notification)
        {
            this._userRepository = userRepository;
            this._notification = notification;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.LoginData, request.Email, request.Password, request.Role);

            if (user == null)
            {
                this._notification.AddNotification("User", Message.RequestInvalid.Description());
            }

            return await this._userRepository.CreateAsync(user);
        }
    }
}
