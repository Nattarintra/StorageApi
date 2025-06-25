using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(15)]
        public required string Name { get; set; } = string.Empty;

        [Range(0, 10000)]
        public int Price { get; set; }
        public required string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public required string Shelf { get; set; } = string.Empty;
        public int Count { get; set; }

        [Required]
        [StringLength(200)]
        public required string Description { get; set; } = string.Empty;
    }
}
