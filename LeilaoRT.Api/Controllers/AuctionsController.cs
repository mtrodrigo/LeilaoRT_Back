using Microsoft.AspNetCore.Mvc;
using LeilaoRT.Domain.Entities;
using LeilaoRT.Api.DTOs;
using LeilaoRT.Api.Mappers;
using LeilaoRT.Api.Services.Interfaces;

namespace LeilaoRT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AuctionResponse> response = _auctionService.GetAll()
                .Select(a => AuctionMapper.ToResponse(a))
                .ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Auction? auction = _auctionService.GetById(id);

            if (auction == null)
            {
                return NotFound();
            }
            return Ok(AuctionMapper.ToResponse(auction));
        }

        [HttpPost]
        public IActionResult Create(CreateAuctionRequest request)
        {
            Auction auction = _auctionService.Create(request);
            return CreatedAtAction(nameof(GetById),
                                   new { id = auction.Id },
                                   AuctionMapper.ToResponse(auction));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAuctionRequest request)
        {
            Auction? auction = _auctionService.Update(id, request);
            if (auction == null)
            {
                return NotFound();
            }
            return Ok(AuctionMapper.ToResponse(auction));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _auctionService.Delete(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
