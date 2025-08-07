using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 30)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0, 2000)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }

        public Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
    }
}
