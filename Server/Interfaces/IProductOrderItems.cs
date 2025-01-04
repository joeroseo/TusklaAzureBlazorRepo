using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Interfaces
{
    public interface IProductOrderItems
    {
        List<ProductOrderItems> GetProductOrderItems();

        List<ProductOrderItems> GetProductOrderItems(int? orderId);

        void AddProductOrderItem(ProductOrderItems productOrderItem);

        void UpdateProductOrderItemDetails(ProductOrderItems productOrderItem);

        ProductOrderItems GetProductOrderItemData(int? orderId);

        void DeleteProductOrderItem(int? orderId);
    }
}
