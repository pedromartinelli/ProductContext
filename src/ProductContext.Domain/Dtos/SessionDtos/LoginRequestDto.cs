using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Dtos.SessionDtos
{
    public class LoginRequestDto
    {

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Password { get; set; }
    }
}
