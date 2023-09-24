using System;

public class InventoryItem : IInventoryItem
{
    public IInventoryItemInfo Info { get; }

    public IInventoryItemState State { get; }

    public Type Type => GetType();

    public IInventoryItem Clone()
    {
        var clonedItem = new InventoryItem(Info);
        clonedItem.State.Amount = State.Amount;
        return clonedItem;
    }

    public InventoryItem(IInventoryItemInfo info)
    {
        Info = info;
        State = new InventoryItemState();
    }
}
