using LeilaoRT.Api.Data;
using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Services.Interfaces;
using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LeilaoRT.Api.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly AppDbContext _context;

        public AuctionService(AppDbContext context)
        {
            _context = context;
        }

        public List<Auction> GetAll()
        {
            return _context.Auctions
                .Include(a => a.Location)
                .Include(a => a.Items)
                    .ThenInclude(a => a.Category)
                .Include(a => a.Items)
                    .ThenInclude(a => a.Location)
                .ToList();
        }

        public Auction? GetById(int id)
        {
            return _context.Auctions
                .Include(a => a.Location)
                .Include(a => a.Items)
                    .ThenInclude (a => a.Category)
                .Include(a => a.Items)
                    .ThenInclude(a => a.Location)
                .FirstOrDefault(auction =>  auction.Id == id);
        }

        public Auction Create(CreateAuctionRequest request)
        {
            Location location = new Location(request.StateCode, request.CityName);

            Auction auction = new Auction(request.Title,
                                          request.Organizer,
                                          request.AuctionDate,
                                          location);
            _context.Auctions.Add(auction);
            _context.SaveChanges();

            return auction;
        }

        public Auction Update(int id, UpdateAuctionRequest request)
        {
            Auction? auction = _context.Auctions.FirstOrDefault(auction => auction.Id == id);
            if (auction == null)
            {
                return null;
            }
            auction.Title = request.Title;
            auction.Organizer = request.Organizer;
            auction.AuctionDate = request.AuctionDate;
            auction.Location = new Location(request.StateCode,
                                            request.CityName);

            _context.SaveChanges();
            return auction;
        }

        public bool Delete(int id)
        {
            Auction? auction = _context.Auctions.FirstOrDefault(auction => auction.Id == id);
            if (auction == null)
            {
                return false;
            }
            _context.Auctions.Remove(auction);
            _context.SaveChanges();
            return true;
        }
    }
}
