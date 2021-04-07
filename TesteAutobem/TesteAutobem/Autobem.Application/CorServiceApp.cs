using Autobem.Application.Interfaces;
using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Application
{
    public class CorServiceApp : BaseServiceApp<Cor>, ICorServiceApp
    {
        private readonly ICorService _service;

        public CorServiceApp(ICorService service) : base(service)
        {
            _service = service;
        }
    }
}
