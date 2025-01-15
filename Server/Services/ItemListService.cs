using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace TusklaBlazor.Server.Services
{

    // ItemListService.cs

    using System.Collections.Generic;
    using TusklaBlazor.Shared.Models;

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