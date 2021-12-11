using CadastroDeVeiculos.Application.Mediator.UserCQRS.Queries;
using CadastroDeVeiculos.Business.Interfaces.Repository;
using CadastroDeVeiculos.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroDeVeiculos.Application.Mediator.UserCQRS.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await this._userRepository.GetAllAsync();
        }
    }
}
