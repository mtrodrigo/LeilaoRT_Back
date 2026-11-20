using LeilaoRT.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LeilaoRT.Api.DTOs
{
    public class CreateItemCostRequest
    {
        [Required, MaxLength(120)]
        public string Description { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal Amount { get; set; }

        public CostNature Nature { get; set; }
    }
}
