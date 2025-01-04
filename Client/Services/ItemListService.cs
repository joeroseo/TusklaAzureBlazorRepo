// TusklaBlazor.Client/Services/ItemListService.cs

using System.Collections.Generic;
using TusklaBlazor.Shared.Models;
using TusklaBlazor.Client.Services;

namespace TusklaBlazor.Client.Services
{
    public class ItemListService : IItemListService
    {
        private readonly List<Item> _itemList = new List<Item>();

        public List<Item> ItemList => _itemList;

        public void AddItem(Item item)
        {
            _itemList.Add(item);
        }
    }
}
