using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductDtoCalc
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public required string Name { get; set; }

        [Range(0, 10000)]
        public int Price { get; set; }

        [Range(0, 1000)]
        public int Count { get; set; }

        public int TotalInventoryValue { get; set; }
    }
}
