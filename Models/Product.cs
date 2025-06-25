using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(15)]
        public string? Name { get; set; }

        [Range(0, 10000)]
        public int Price { get; set; }
        public required string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string? Shelf { get; set; }
        public int Count { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
    }
}
