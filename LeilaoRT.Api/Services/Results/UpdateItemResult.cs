using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.Enums;

namespace LeilaoRT.Api.Services.Results
{
    public class UpdateItemResult
    {
        public bool Success { get; private set; }
        public Item? Item {  get; private set; }
        public UpdateItemError Error { get; private set; }

        public static UpdateItemResult CreateSuccess(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return new UpdateItemResult
            {
                Success = true,
                Item = item,
                Error = UpdateItemError.None
            };
        }

        public static UpdateItemResult CreateFailure(UpdateItemError error)
        {
            if (error == UpdateItemError.None)
            {
                throw new ArgumentException(nameof(error));
            }
            return new UpdateItemResult
            {
                Success = false,
                Item = null,
                Error = error
            };
        }
    }
}
