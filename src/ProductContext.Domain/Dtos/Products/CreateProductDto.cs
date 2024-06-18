using System.ComponentModel.DataAnnotations;

namespace ProductContext.Domain.Dtos.Product
{
    public class CreateProductDto
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "A descrição deve conter no máximo 200 caracteres")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço não pode ser um valor negativo")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser um valor negativo")]
        public int Quantity { get; set; }
    }
}
