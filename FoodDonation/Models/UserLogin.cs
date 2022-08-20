using System.ComponentModel.DataAnnotations;

namespace FoodDonation.Models
{
    public class UserLogin
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
