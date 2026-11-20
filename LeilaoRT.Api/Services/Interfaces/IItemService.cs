using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Services.Results;
using LeilaoRT.Domain.Entities;

namespace LeilaoRT.Api.Services.Interfaces
{
    public interface IItemService
    {
        CreateItemResult Create(CreateItemRequest request);
        Item? GetById(int id);
        List<Item> GetAll();
        UpdateItemResult Update(int id, UpdateItemRequest request);
        bool Delete(int id);
    }
}
