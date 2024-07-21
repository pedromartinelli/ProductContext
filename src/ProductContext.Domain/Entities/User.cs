using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProductContext.Domain.Dtos.UserDtos;

namespace ProductContext.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User()
        {
            CreateRecord();
        }

        public static User CreateFromDto(CreateUserRequestDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                BirthDate = dto.BirthDate,
            };
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        [JsonIgnore]
        public string PasswordHash { get; private set; }
        public DateTime BirthDate { get; private set; }
        public IList<Role> Roles { get; private set; } = new List<Role>();
    }
}
