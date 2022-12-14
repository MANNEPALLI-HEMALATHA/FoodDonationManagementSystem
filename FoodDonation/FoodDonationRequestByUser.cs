using System.ComponentModel.DataAnnotations;

namespace FoodDonation
{
    public class FoodDonationRequestByUser
    {
        //User Willing to Donate Food
        [Key]
        public int RequestId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string PurposeofDonation { get; set; }
        [Required]
        public int NoOfFoodPackets { get; set; }
    }
}
