
namespace ShopBridge.Infrastrusture.Models
{
    public class ProductRequest
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
