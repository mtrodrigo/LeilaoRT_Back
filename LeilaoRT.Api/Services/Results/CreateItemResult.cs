using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.Enums;
using Microsoft.Identity.Client.NativeInterop;

namespace LeilaoRT.Api.Services.Results
{
    public class CreateItemResult
    {
        public bool Success { get; private set; }
        public Item? Item { get; private set; }
        public CreateItemError Error { get; private set; }

        public static CreateItemResult CreateSuccess(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));                    
            }
            return new CreateItemResult
            {
                Success = true,
                Item = item,
                Error = CreateItemError.None
            };
        }

        public static CreateItemResult CreateFailure(CreateItemError error)
        {
            if (error == CreateItemError.None)
            {
                throw new ArgumentException(nameof(error));
            }
            return new CreateItemResult
            {
                Success = false,
                Item = null,
                Error = error
            };

        }
    }
}
