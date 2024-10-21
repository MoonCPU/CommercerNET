namespace Ecommerce.Models
{
    public class OrderItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
