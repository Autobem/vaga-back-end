using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Domain.Interfaces
{
    public interface ILoginRepository : IRepository<User>
    {
        Task<User> FindByLogin(string email, string password);
    }
}
