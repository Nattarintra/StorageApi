using StorageApi.DTOs;
using StorageApi.Models.Entities;

namespace StorageApi.Controllers.Services
{
    public class ProductService
    {
        public ProductDTOCalc GetCalculatedProduct(Product product)
        {
            var tocalInventoryValue = product.Price * product.Count;
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            return new ProductDTOCalc
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                TotalInventoryValue = tocalInventoryValue

            };
        }
    }
}
