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
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }


        [HttpPost]
        public IActionResult Create(CreateItemRequest request)
        {
            CreateItemResult result = _itemService.Create(request);

            if (!result.Success)
            {
                switch (result.Error)
                {
                    case CreateItemError.AuctionNotFound:
                        return NotFound("Auction not found");
                    case CreateItemError.CategoryNotFound:
                        return NotFound("Category not found");
                    case CreateItemError.DuplicateLot:
                        return Conflict("An item with this lot number already exists in this auction.");
                    default:
                        return BadRequest("Unexpected error while creating the item.");
                }
            }
            if (result.Item == null)
            {
                return StatusCode(500, "Unexpected error while creating the item.");
            }

            Item item = result.Item;
           
            return CreatedAtAction(nameof(GetById),
                                   new {id = item.Id},
                                   ItemMapper.ToResponse(item));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Item? item = _itemService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(ItemMapper.ToResponse(item));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ItemResponse> response = _itemService.GetAll()
                 .Select(item => ItemMapper.ToResponse(item))
                 .ToList();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateItemRequest request)
        {
            UpdateItemResult result = _itemService.Update(id, request);
            
            if (!result.Success)
            {
                switch (result.Error)
                {
                    case UpdateItemError.ItemNotFound:
                        return NotFound("Item not found");
                    case UpdateItemError.AuctionNotFound:
                        return NotFound("Auction not found");
                    case UpdateItemError.CategoryNotFound:
                        return NotFound("Category not found");
                    case UpdateItemError.DuplicateLot:
                        return Conflict("An item with this lot number already exists in this auction.");
                    default:
                        return BadRequest("While updating the item");
                }
            }
            if (result.Item == null)
            {
                return StatusCode(500, "Unexpected error while updating the item.");
            }

            Item item = result.Item;

            return Ok(ItemMapper.ToResponse(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _itemService.Delete(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
