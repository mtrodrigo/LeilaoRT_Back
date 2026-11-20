using LeilaoRT.Domain.Enums;
using LeilaoRT.Domain.ValueObjects;

namespace LeilaoRT.Api.DTOs
{
    public class AuctionResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Organizer { get; set; }
        public DateTime AuctionDate { get; set; }
        public string Status { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public List<ItemResponse> Items { get; set; }
    }
}
