using Autobem.Application.Interfaces;
using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Application
{
    public class ProprietarioServiceApp : BaseServiceApp<Proprietario>, IProprietarioServiceApp
    {
        private readonly IProprietarioService _service;

        public ProprietarioServiceApp(IProprietarioService service) : base(service)
        {
            _service = service;
        }
    }
}
