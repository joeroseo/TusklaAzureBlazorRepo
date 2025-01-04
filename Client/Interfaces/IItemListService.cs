
// IItemListService.cs

using System.Collections.Generic;
using TusklaBlazor.Shared.Models;


public interface IItemListService
{
    List<Item> ItemList { get; }
    void AddItem(Item item);
}
