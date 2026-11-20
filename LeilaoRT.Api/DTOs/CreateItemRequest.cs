using System.ComponentModel.DataAnnotations;

namespace LeilaoRT.Api.DTOs
{
    public class CreateItemRequest
    {
        [Range(1, int.MaxValue)]
        public int AuctionId { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue)]
        public int LotNumber { get; set; }

        [Required, StringLength(120)]
        public string Title { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal ReferenceValue { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal EstimatedSaleValue { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal PurchaseValue { get; set; }

        [Required, StringLength(2, MinimumLength = 2)]
        public string StateCode { get; set; }

        [Required, StringLength(120)]
        public string CityName { get; set; }
    }
}
