using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductContext.Domain.Dtos.SessionDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Interfaces
{
    public interface ISessionService
    {
        Task<User> LoginAsync(LoginRequestDto dto);
    }
}
