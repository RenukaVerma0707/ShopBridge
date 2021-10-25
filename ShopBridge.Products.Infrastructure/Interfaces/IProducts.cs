using ShopBridge.Infrastrusture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Infrastrusture.Interfaces
{
    public interface IProducts
    {
        Task<List<Products>> GetProducts();
        Task<Products> AddProduct(ProductRequest products);
        Task<string> UpdateProduct(Products products);
        Task<string> Delete(Guid id);
    }
}
