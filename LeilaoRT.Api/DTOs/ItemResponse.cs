using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.DTOs
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public int LotNumber { get; set; }
        public string Title { get; set; }
        public decimal ReferenceValue { get; set; }
        public decimal EstimatedSaleValue { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal TotalCosts { get; set; }
        public decimal TotalInvestment { get; set; }
        public decimal EstimatedProfit { get; set; }
        public decimal EstimatedRoi { get; set; }
        public int AuctionId { get; set; }
        public int CategoryId { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public List<ItemCostResponse> Costs { get; set; }
    }
}
