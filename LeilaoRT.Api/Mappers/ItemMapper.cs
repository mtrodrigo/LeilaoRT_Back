using LeilaoRT.Api.DTOs;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Mappers
{
    public static class ItemMapper
    {
        public static ItemResponse ToResponse(Item item)
        {
            return new ItemResponse
            {
                Id = item.Id,
                LotNumber = item.LotNumber,
                Title = item.Title,
                ReferenceValue = item.ReferenceValue,
                EstimatedSaleValue = item.EstimatedSaleValue,
                PurchaseValue = item.PurchaseValue,
                TotalCosts = item.CalculateTotalCosts(),
                TotalInvestment = item.CalculateTotalInvestment(),
                EstimatedProfit = item.CalculateEstimatedProfit(),
                EstimatedRoi = item.CalculateEstimatedRoi(),
                AuctionId = item.Auction.Id,
                CategoryId = item.Category.Id,
                StateCode = item.Location.StateCode,
                CityName = item.Location.CityName,
                Costs = item.Costs
                    .Select(cost => ItemCostMapper.ToResponse(cost))
                    .ToList()
            };
        }
    }
}
