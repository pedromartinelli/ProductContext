using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductContext.Domain.Dtos.UserDtos
{
    public class CreateUserRequestDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Length(2, 100, ErrorMessage = "O nome deve conter no mínimo 2")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [Length(2, 100, ErrorMessage = "A senha deve conter no mínimo 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
