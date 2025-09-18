using System;

namespace MyShop.Models
{
    // Simple item/product model
    public class Item
    {
        // Unique identifier for the item
        public int ItemId { get; set; }

        // Name of the item
        public string Name { get; set; } = string.Empty;

        // Price of the item
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        //navigation property
        public virtual List<OrderItem>? OrderItems { get; set; }
    }
}