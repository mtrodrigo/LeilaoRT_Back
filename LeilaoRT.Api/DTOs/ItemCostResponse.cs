namespace LeilaoRT.Api.DTOs
{
    public class ItemCostResponse
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Nature { get; set; }
    }
}
