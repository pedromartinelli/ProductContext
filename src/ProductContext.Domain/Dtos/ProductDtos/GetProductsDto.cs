using System.ComponentModel.DataAnnotations;

namespace ProductContext.Domain.Dtos.ProductDtos
{
    public class GetProductsDto
    {
        [Range(0, double.MaxValue, ErrorMessage = "A página não pode ser um valor negativo")]
        public int Page { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A quantidade de itens por página não pode ser um valor negativo")]
        public int PageSize { get; set; }
    }
}
