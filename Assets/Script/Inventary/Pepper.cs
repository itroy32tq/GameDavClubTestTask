using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : IInventoryItem
{
    public IInventoryItemInfo Info { get; }

    public IInventoryItemState State { get; }

    public Type Type { get; }

    public IInventoryItem Clone()
    {
        var clonedPepper = new Pepper(Info);
        clonedPepper.State.Amount = State.Amount;
        return clonedPepper;
    }
    public Pepper(IInventoryItemInfo info)
    {
        Info = info;
        State = new InventoryItemState();
    }
}
