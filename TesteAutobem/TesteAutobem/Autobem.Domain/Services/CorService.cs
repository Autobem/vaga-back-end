using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Repositories;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Domain.Services
{
    public class CorService : BaseService<Cor>, ICorService
    {
        private readonly ICorRepository _repository;

        public CorService(ICorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
