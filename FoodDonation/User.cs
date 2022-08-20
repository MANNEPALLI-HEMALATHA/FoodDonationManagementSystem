
using System.ComponentModel.DataAnnotations;

namespace FoodDonation
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Donor Category")]
        public string DonorCategory { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int RollId { get; set; }
    }
    /*public enum Gender
    {
        Male, Female
    }*/
}
