using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.SessionDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Services
{
    public class SessionService(IUserService userService, IPasswordHashService hashService) : ISessionService
    {
        public async Task<User> LoginAsync(LoginRequestDto dto)
        {
            try
            {
                var user = await userService.GetByEmailAsync(dto.Email);

                var verify = hashService.VerifyPassword(dto.Password, user.PasswordHash);
                if (!verify) throw new ApplicationException("E-mail ou senha inválidos");

                return user;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("E-mail ou senha inválidos");
            }
        }
    }
}
