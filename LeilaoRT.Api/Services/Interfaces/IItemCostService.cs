using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Services.Results;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Services.Interfaces
{
    public interface IItemCostService
    {
        CreateItemCostResult Create(int itemId, CreateItemCostRequest request);
        ItemCost? GetById(int id);
        List<ItemCost> GetByItemId(int itemId);
    }
}
