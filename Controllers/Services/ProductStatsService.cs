using StorageApi.DTOs;
using StorageApi.Models.Entities;

namespace StorageApi.Controllers.Services
{
    public class ProductStatsService
    {
        public ProductDtoStats GetProductStats(List<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products), "Product cannot be null");
            }

           
            var totalPrice = products.Sum(p => p.Price * p.Count);
            var averagePrice = products.Sum(p => totalPrice / p.Count);
            var tocalInventoryValue = products.Count;


            var productStats = new ProductDtoStats
            {
                TotalPrice = totalPrice,
                AveragePrice = averagePrice,
                TotalInventoryValue = tocalInventoryValue,

            };
            return productStats;


        }
    }
}
