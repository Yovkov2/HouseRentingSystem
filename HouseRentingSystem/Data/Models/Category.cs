using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        // Use ICollection<House> so EF Core can track adds/removes
        public ICollection<House> Houses { get; set; }
            = new List<House>();
    }
}