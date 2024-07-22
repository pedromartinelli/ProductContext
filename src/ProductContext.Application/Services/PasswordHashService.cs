using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductContext.Application.Interfaces;

namespace ProductContext.Application.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
             => BCrypt.Net.BCrypt.HashPassword(password);


        public bool VerifyPassword(string password, string hashedPassword)
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
