using LeilaoRT.Api.DTOs;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Mappers
{
    public static class AuctionMapper
    {
        public static AuctionResponse ToResponse(Auction response)
        {

            return new AuctionResponse
            {
                Id = response.Id,
                Title = response.Title,
                Organizer = response.Organizer,
                AuctionDate = response.AuctionDate,
                Status = response.Status.ToString(),
                StateCode = response.Location.StateCode,
                CityName = response.Location.CityName,
                Items = response.Items
                    .Select(item => ItemMapper.ToResponse(item))
                    .ToList()
            };
        }
    }
}
