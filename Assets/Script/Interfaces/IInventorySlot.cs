using Script.ItemSpace;
using System;

namespace Script.Interfaces
{
    public interface IInventorySlot
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        Item Item { get; }
        Type ItemType { get; }
        string ItemId { get; }
        int Amount { get; }
        int Capacity { get; set; }
        void SetItem(Item item);
        void Clear();
    }
}


