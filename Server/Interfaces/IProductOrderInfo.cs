using System.Collections.Generic;
using TusklaBlazor.Server.Models;


namespace TusklaBlazor.Server.Interfaces
{
    public interface IProductOrderInfo
    {
        List<ProductOrderInfo> GetProductOrderInfo();

        int AddProductOrderInfo(ProductOrderInfo productOrderInfo); // Change return type to int

        void UpdateProductOrderInfoDetails(ProductOrderInfo productOrderInfo);

        ProductOrderInfo GetProductOrderInfoData(int orderId);

        void DeleteProductOrderInfo(int orderId);
    }
}
