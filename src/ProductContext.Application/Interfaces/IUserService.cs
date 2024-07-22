using ProductContext.Domain.Dtos.UserDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequestDto dto);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
    }
}
