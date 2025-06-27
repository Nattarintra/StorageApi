using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(15)]
        public required string Name { get; set; }

        [Range(0, 10000)]
        public int Price { get; set; }

        public required string Category { get; set; }

        [Required]
        [StringLength(20)]
        public required string Shelf { get; set; }

        public int Count { get; set; }

        [Required]
        [StringLength(200)]
        public required string Description { get; set; }
    }
}

        