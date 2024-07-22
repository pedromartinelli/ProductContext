using ProductContext.Domain.Entities;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Interfaces.Repositories;
using ProductContext.Domain.Dtos.UserDtos;

namespace ProductContext.Application.Services
{
    public class UserService(IUserRepository repository, IPasswordHashService hashService) : IUserService
    {
        public async Task<User> CreateAsync(CreateUserRequestDto dto)
        {
            var existingUser = await repository.VerifyEmailExists(dto.Email);
            if (existingUser) throw new ApplicationException("Já existe um usuário cadastrado com esse E-mail.");

            var hashedPassword = hashService.HashPassword(dto.Password);

            var user = new User(dto.Name, dto.Email, hashedPassword, dto.BirthDate);
            await repository.CreateAsync(user);

            return user;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            if (user == null) throw new ApplicationException("Não existe um usuário com o Id informado.");

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);

            if (user == null) throw new ApplicationException("Não existe um usuário com o E-mail informado.");

            return user;
        }
    }
}
