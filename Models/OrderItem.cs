namespace Ecommerce.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        //foreign key reference
        public int OrderId { get; set; }

        //product details
        public string Title { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public string Image { get; set; } = string.Empty; 

        //order item specifics
        public int Quantity { get; set; } 
        public decimal ProductPrice { get; set; }

        public required Order Order { get; set; }
    }
}
