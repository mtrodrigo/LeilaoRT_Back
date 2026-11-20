using LeilaoRT.Api.DTOs;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Services.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction? GetById(int id);
        Auction Create(CreateAuctionRequest request);
        Auction? Update(int id, UpdateAuctionRequest request);
        bool Delete(int id);
    }
}
