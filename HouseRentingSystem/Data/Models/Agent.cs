using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
