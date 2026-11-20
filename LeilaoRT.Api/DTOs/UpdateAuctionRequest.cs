using System.ComponentModel.DataAnnotations;

namespace LeilaoRT.Api.DTOs
{
    public class UpdateAuctionRequest
    {
        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(120)]
        public string Organizer { get; set; }

        public DateTime AuctionDate { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string StateCode { get; set; }

        [Required]
        [StringLength (120)]
        public string CityName { get; set; }
    }
}
