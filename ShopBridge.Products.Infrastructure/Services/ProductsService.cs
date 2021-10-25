using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopBridge.Infrastrusture.Interfaces;
using ShopBridge.Infrastrusture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Infrastrusture.Services
{
    public class ProductsService : IProducts
    {
        private readonly ProductDbContext _productDbContext;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(ProductDbContext productDbContext, ILogger<ProductsService> logger)
        {
            _productDbContext = productDbContext;
            _logger = logger;
        }

        public async Task<Products> AddProduct(ProductRequest products)
        {

            Products product = Utility.Utility.ModelToEntity(products);
            await _productDbContext.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<string> Delete(Guid id)
        {
            var products = await _productDbContext.Products.Where(x => x.ProductId == id).AsNoTracking().FirstOrDefaultAsync();
            if (products != null)
            {
                _productDbContext.Products.Remove(products);
                await _productDbContext.SaveChangesAsync();
                return "Product deleted successfully";

            }
            return null;
        }

        public async Task<List<Products>> GetProducts()
        {
            var products = await _productDbContext.Products.AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<string> UpdateProduct(Products product)
        {
            var products = await _productDbContext.Products.Where(x => x.ProductId == product.ProductId).AsNoTracking().FirstOrDefaultAsync();


            if (products != null)
            {
                var result = _productDbContext.Update(product);
                await _productDbContext.SaveChangesAsync();
                return "Product updated successfully";
            }
            return null;

        }

    }
}
