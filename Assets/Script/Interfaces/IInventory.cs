using Script.ItemSpace;
using System;

namespace Script.Interfaces
{
    public interface IInventory
    {
        int Capacity { get; set; }
        bool IsFull { get; }
        Item GetItem(Type itemType);
        Item GetItem(string id);
        Item[] GetAllItems();
        Item[] GetAllItems(Type itemType);
        Item[] GetAllItems(string id);
        Item[] GetEquippedItems();
        int GetItemAmout(Type itemType);
        bool TryToAdd(object sender, Item item);
        void Remove(object sender, string itemId, int amout = 1);
        bool HasItem(Type type, out Item item);
    }
}
