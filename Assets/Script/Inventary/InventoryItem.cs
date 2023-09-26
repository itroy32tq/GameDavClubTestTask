using Assets.Script.Interfaces;
using System;

namespace Script.Inventoty
{
    public class InventoryItem : IInventoryItem
    {
        public IItemInfo Info { get; }
        public IInventoryItemState State { get; }
        public Type Type => GetType();
        public IInventoryItem Clone()
        {
            var clonedItem = new InventoryItem(Info);
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }
        public InventoryItem(IItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }
    }
}

