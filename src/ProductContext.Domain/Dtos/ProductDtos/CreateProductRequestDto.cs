using System.ComponentModel.DataAnnotations;

namespace ProductContext.Domain.Dtos.ProductDtos
{
    public class CreateProductRequestDto
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Length(2, 100, ErrorMessage = "O nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; set; }

        [Length(0, 200, ErrorMessage = "A descrição deve conter no máximo 200 caracteres")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, MinimumIsExclusive = false, ErrorMessage = "O preço não pode ser um valor negativo")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, MinimumIsExclusive = false, ErrorMessage = "A quantidade em estoque não pode ser um valor negativo")]
        public int Quantity { get; set; }
    }
}
