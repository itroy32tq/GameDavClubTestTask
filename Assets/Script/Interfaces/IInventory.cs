using System;

namespace Assets.Script.Interfaces
{
    public interface IInventory
    {
        int Capacity { get; set; }
        bool IsFull { get; }
        IInventoryItem GetItem(Type itemType);
        IInventoryItem GetItem(string id);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type itemType);
        IInventoryItem[] GetAllItems(string id);
        IInventoryItem[] GetEquippedItems();
        int GetItemAmout(Type itemType);
        bool TryToAdd(object sender, IInventoryItem item);
        void Remove(object sender, string itemId, int amout = 1);
        bool HasItem(Type type, out IInventoryItem item);
    }
}
