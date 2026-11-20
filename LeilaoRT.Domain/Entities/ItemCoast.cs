using LeilaoRT.Domain.Enums;

namespace LeilaoRT.Domain.Entities
{
    public class ItemCost
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public CostNature Nature { get; set; }
        public  int ItemId { get; set; }
        public Item Item { get; set; }

        public ItemCost() { }

        public ItemCost(string description, 
                        decimal amount,
                        CostNature nature,
                        Item item) 
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty", nameof(description));
            }

            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative", nameof(amount));
            }

            Description = description;
            Amount = amount;
            Nature = nature;
            ItemId = item.Id;
            Item = item;
        }
    }
}
