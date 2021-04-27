using AutoBem.Domain.Users.Services;
using BuildingBlocks.Application.Requests;
using BuildingBlocks.Ioc.Attributes;
using System.Threading;
using System.Threading.Tasks;

namespace AutoBem.Application.Users.Query.Register
{
    [Injectable]
    public class SigninUserQueryHandler : IRequestHandler<SigninUserQuery, SigninUserResult>
    {
        [Inject]
        public IAuthenticationService Service { get; set; }

        public Task<SigninUserResult> Handle(SigninUserQuery request, CancellationToken cancellationToken)
        {
            var result = Service.Signin(request.Username, request.Password);

            return Task.FromResult(new SigninUserResult(result));
        }
    }
}
