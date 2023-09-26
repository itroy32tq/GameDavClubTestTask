using System;

namespace Assets.Script.Interfaces
{
    public interface IInventoryItem
    {
        IItemInfo Info { get; }
        IInventoryItemState State { get; }
        Type Type { get; }
        IInventoryItem Clone();
    }
}
