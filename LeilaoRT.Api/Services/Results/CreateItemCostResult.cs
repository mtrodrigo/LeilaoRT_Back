using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.Enums;

namespace LeilaoRT.Api.Services.Results
{
    public class CreateItemCostResult
    {
        public bool Success { get; private set; }
        public ItemCost? ItemCost { get; private set; }
        public CreateItemCostError Error { get; private set; }

        public static CreateItemCostResult CreateSuccess(ItemCost itemCost)
        {
            if (itemCost == null)
            {
                throw new ArgumentNullException(nameof(itemCost));
            }
            return new CreateItemCostResult
            {
                Success = true,
                ItemCost = itemCost,
                Error = CreateItemCostError.None
            };
        }

        public static CreateItemCostResult CreateFailure(CreateItemCostError error)
        {
            if (error == CreateItemCostError.None)
            {
                throw new ArgumentException(nameof(error));
            }
            return new CreateItemCostResult
            {
                Success = false,
                ItemCost = null,
                Error = error
            };

        }
    }
}
