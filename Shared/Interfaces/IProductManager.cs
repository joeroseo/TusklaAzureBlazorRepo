using System.Collections.Generic;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Shared.Models;
using TusklaBlazor.Shared.Interfaces;
using TusklaBlazor.Shared.Services;

namespace TusklaBlazor.Shared.Interfaces
{
    public interface IProductManager
    {
        List<Product> GetProducts();

        int AddProduct(Product product);

        void UpdateProductDetails(Product product);

        Product GetProductData(int productId);

        void DeleteProduct(int productId);
    }
}
