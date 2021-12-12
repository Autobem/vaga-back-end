using CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserLoginQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;

        }

        public async Task<User> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            return await this._userRepository.GetLogin(request.Login, request.Password);
        }
    }
}
