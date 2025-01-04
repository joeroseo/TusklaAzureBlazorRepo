
// IItemListService.cs

using System.Collections.Generic;
using TusklaBlazor.Shared.Models;
using TusklaBlazor.Server.Services;

public interface IItemListService
{
    List<Item> ItemList { get; }
    void AddItem(Item item);
}
