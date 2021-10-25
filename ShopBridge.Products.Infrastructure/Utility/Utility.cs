using ShopBridge.Infrastrusture.Models;

namespace ShopBridge.Infrastrusture.Utility
{
    public class Utility
    {
        public static Products ModelToEntity(ProductRequest model)
        {
            Products product = new Products()
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Price = model.Price,
                Quantity = model.Quantity
            };
            return product;
        }
    }
}
