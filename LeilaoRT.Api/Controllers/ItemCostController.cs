using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Mappers;
using LeilaoRT.Api.Services.Interfaces;
using LeilaoRT.Api.Services.Results;
using LeilaoRT.Domain.Entities;
using LeilaoRT.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoRT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCostController : ControllerBase
    {
        private readonly IItemCostService _itemCostService;
        public ItemCostController(IItemCostService itemCostService)
        {
            _itemCostService = itemCostService;
        }

        [HttpPost("{itemId}/costs")]
        public IActionResult Create(int itemId, CreateItemCostRequest request)
        {
            CreateItemCostResult result = _itemCostService.Create(itemId, request);

            if (!result.Success)
            {
                switch(result.Error)
                {
                    case CreateItemCostError.ItemNotFound:
                        return NotFound("Item not found");
                    default:
                        return BadRequest("Unexpected error while creating the item cost.");
                }
            }

            if (result.ItemCost == null)
            {
                return StatusCode(500, "Unexpected error while creating the item cost.");
            }

            ItemCost itemCost = result.ItemCost;

            return CreatedAtAction(nameof(GetById),
                                   new { id = itemCost.Id },
                                   ItemCostMapper.ToResponse(itemCost));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ItemCost? itemCost = _itemCostService.GetById(id);
            if (itemCost == null)
            {
                return NotFound();
            }

            return Ok(ItemCostMapper.ToResponse(itemCost));
        }

        [HttpGet("item/{itemId}")]
        public IActionResult GetByItemId(int itemId)
        {
            List<ItemCostResponse> response = _itemCostService.GetByItemId(itemId)
                .Select(itemCost => ItemCostMapper.ToResponse(itemCost))
                .ToList();
            return Ok(response);
        }
    }
}
