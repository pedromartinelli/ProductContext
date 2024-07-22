using ProductContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Interfaces.Repositories;

namespace ProductContext.Infra.Data.Repositories
{
    public class UserRepository(ProductDbContext context) : IUserRepository
    {
        public async Task<User> CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetByIdAsync(Guid id)
            => await context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<User?> GetByEmailAsync(string email)
            => await context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

            public async Task<bool> VerifyEmailExists(string email)
            => await context.Users.AnyAsync(x => x.Email.Equals(email));
    }
}
