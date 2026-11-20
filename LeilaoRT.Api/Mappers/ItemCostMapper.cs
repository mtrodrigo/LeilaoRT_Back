using LeilaoRT.Api.DTOs;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Mappers
{
    public static class ItemCostMapper
    {
        public static ItemCostResponse ToResponse(ItemCost itemCost)
        {
            return new ItemCostResponse
            {
                Id = itemCost.Id,
                ItemId = itemCost.ItemId,
                Description = itemCost.Description,
                Amount = itemCost.Amount,
                Nature = itemCost.Nature.ToString(),
            };
        }
    }
}
