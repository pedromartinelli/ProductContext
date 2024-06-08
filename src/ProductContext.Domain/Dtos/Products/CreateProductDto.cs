using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Dtos.Product
{
    public class CreateProductDto
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; private set; }

        [StringLength(200, ErrorMessage = "A descrição deve conter no máximo 200 caracteres")]
        public string Description { get; private set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço não pode ser um valor negativo")]
        public decimal Price { get; private set; }

        [Range(0, double.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser um valor negativo")]
        public int Quantity { get; private set; }
    }
}
