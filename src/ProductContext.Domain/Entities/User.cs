using ProductContext.Domain.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace ProductContext.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }

        public User(string name, string email, string passwordHash, DateTime birthDate)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            BirthDate = birthDate;
            CreateRecord();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        [JsonIgnore]
        public string PasswordHash { get; private set; }
        public DateTime BirthDate { get; private set; }
        public IList<Role> Roles { get; private set; } = new List<Role>();

        public static User FromDto(CreateUserRequestDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password,
                BirthDate = dto.BirthDate,
            };
        }

    }
}
