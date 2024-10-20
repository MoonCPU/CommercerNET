namespace Ecommerce.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public required string UserId { get; set; }
        public decimal TotalPrice { get; set; } 
        public DateTime OrderDate { get; set; } 

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
