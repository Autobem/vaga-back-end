using CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;


        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await this._userRepository.GetByIdAsync(request.Id);
        }
    }
}
