using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.UserDtos;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces.Repositories;

namespace ProductContext.Application.Services
{
    public class UserService(IUserRepository repository, IPasswordHashService hashService) : IUserService
    {
        public async Task<User> CreateAsync(CreateUserRequestDto dto)
        {
            var existingUser = await repository.VerifyEmailExists(dto.Email);
            if (existingUser)
                throw new ApplicationException("Já existe um usuário cadastrado com esse E-mail.");

            dto.Password = hashService.HashPassword(dto.Password);

            var user = User.FromDto(dto);

            await repository.CreateAsync(user);

            return user;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            return user ?? throw new ApplicationException("Não existe um usuário com o Id informado.");
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);

            return user ?? throw new ApplicationException("Não existe um usuário com o E-mail informado.");
        }
    }
}
