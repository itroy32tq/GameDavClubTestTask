using System;

namespace Assets.Script.Interfaces
{
    public interface IInventorySlot
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        IInventoryItem Item { get; }
        Type ItemType { get; }
        string ItemId { get; }
        int Amount { get; }
        int Capacity { get; set; }
        void SetItem(IInventoryItem item);
        void Clear();
    }
}


