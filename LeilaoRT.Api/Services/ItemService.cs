using LeilaoRT.Api.Data;
using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Services.Results;
using LeilaoRT.Api.Services.Interfaces;
using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.ValueObjects;
using LeilaoRT.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LeilaoRT.Api.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public CreateItemResult Create(CreateItemRequest request)
        {
            Auction? auction = _context.Auctions
                .FirstOrDefault(auction => auction.Id == request.AuctionId);
            if (auction == null)
            {
                return CreateItemResult.CreateFailure(CreateItemError.AuctionNotFound);
            }
            Category? category = _context.Categories
                .FirstOrDefault(category => category.Id == request.CategoryId);
            if (category == null)
            {
                return CreateItemResult.CreateFailure(CreateItemError.CategoryNotFound);
            }
            bool lotAlreadyExists = _context.Items
                .Any(item => item.AuctionId == request.AuctionId && item.LotNumber == request.LotNumber);
            if (lotAlreadyExists)
            {
                return CreateItemResult.CreateFailure(CreateItemError.DuplicateLot);
            }

            Location location = new Location(request.StateCode,
                                             request.CityName);

            Item item = new Item(request.LotNumber,
                                 request.Title,
                                 request.ReferenceValue,
                                 request.EstimatedSaleValue,
                                 request.PurchaseValue,
                                 category,
                                 location,
                                 auction);
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }

            return CreateItemResult.CreateSuccess(item);
        }

        public Item? GetById(int id)
        {
            return _context.Items
                .Include(a => a.Auction)
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Costs)
                .FirstOrDefault(item => item.Id == id);
        }

        public List<Item> GetAll()
        {
            return _context.Items
                .Include(a => a.Auction)
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Costs)
                .ToList();
        }

        public UpdateItemResult Update(int id, UpdateItemRequest request)
        {
            Item? item = GetById(id);
            if (item == null)
            {
                return UpdateItemResult.CreateFailure(UpdateItemError.ItemNotFound);
            }
            Auction? auction = _context.Auctions
                .FirstOrDefault(auction => auction.Id == request.AuctionId);
            if (auction == null)
            {
                return UpdateItemResult.CreateFailure(UpdateItemError.AuctionNotFound);
            }
            Category? category = _context.Categories
                .FirstOrDefault(category => category.Id == request.CategoryId);
            if (category == null)
            {
                return UpdateItemResult.CreateFailure(UpdateItemError.CategoryNotFound);
            }
            bool lotAlreadyExists = _context.Items
                .Any(item => item.Id != id &&
                     item.AuctionId == request.AuctionId &&
                     item.LotNumber == request.LotNumber);
            if (lotAlreadyExists)
            {
                return UpdateItemResult.CreateFailure(UpdateItemError.DuplicateLot);
            }
            Location location = new Location(request.StateCode, request.CityName);

            item.LotNumber = request.LotNumber;
            item.Title = request.Title;
            item.ReferenceValue = request.ReferenceValue;
            item.EstimatedSaleValue = request.EstimatedSaleValue;
            item.PurchaseValue = request.PurchaseValue;
            item.Category = category;
            item.Auction = auction;
            item.AuctionId = request.AuctionId;
            item.Location = location;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }

            return UpdateItemResult.CreateSuccess(item);
        }

        public bool Delete(int id)
        {
            Item? item = _context.Items
                .FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return false;
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return true;
        }
    }
}
