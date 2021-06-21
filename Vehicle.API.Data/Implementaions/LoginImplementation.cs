using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Data.Context;
using Vehicles.API.Data.Repository;
using Vehicles.API.Domain.Entities;
using Vehicles.API.Domain.Interfaces;

namespace Vehicles.API.Data.Implementaions
{
    public class LoginImplementation : BaseRepository<User>, ILoginRepository
    {
        private DbSet<User> _dataset;

        public LoginImplementation(MyContext context) : base(context)
        {
            this._dataset = context.Set<User>();
        }
        public async Task<User> FindByLogin(string email, string password)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
