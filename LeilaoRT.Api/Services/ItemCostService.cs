using LeilaoRT.Api.Data;
using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Services.Interfaces;
using LeilaoRT.Api.Services.Results;
using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LeilaoRT.Api.Services
{
    public class ItemCostService : IItemCostService
    {
        private readonly AppDbContext _context;
        public ItemCostService(AppDbContext context)
        {
            _context = context;
        }

        public CreateItemCostResult Create(int itemId, CreateItemCostRequest request)
        {
            Item? item = _context.Items
                .FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                return CreateItemCostResult.CreateFailure(CreateItemCostError.ItemNotFound);
            }
            ItemCost itemCost = new ItemCost(request.Description,
                                             request.Amount,
                                             request.Nature,
                                             item);
            try
            {
                _context.Costs.Add(itemCost);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
            return CreateItemCostResult.CreateSuccess(itemCost);
        }

        public ItemCost? GetById(int id)
        {
            return _context.Costs
                .FirstOrDefault(c => c.Id == id);
        }

        public List<ItemCost> GetByItemId(int itemId)
        {
            return _context.Costs
                .Where(c => c.ItemId == itemId)
                .ToList();
        }
    }
}
