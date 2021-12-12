﻿using CadastroDeVeiculos.Application.Mediator.UserCQRS.Commands;
using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;

        public UserUpdateCommandHandler(IUserRepository userRepository, INotificationContext notification)
        {
            this._userRepository = userRepository;
            this._notification = notification;
        }

        public async Task<User> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                this._notification.AddNotification("User", Message.NotFound.Description());
            }

            user.UserUpdate(request.LoginData, request.Email, request.Password, request.Role);
            return await _userRepository.UpdateAsync(user);
        }
    }
}
