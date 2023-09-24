using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : IInventoryItem
{

    public Type Type => GetType();

    public IInventoryItemInfo Info { get; }

    public IInventoryItemState State { get; }

    public IInventoryItem Clone()
    {
        var clonedApple = new Apple(Info);
        clonedApple.State.Amount = State.Amount;
        return clonedApple;
    }
    public Apple(IInventoryItemInfo info) 
    {
        Info = info;
        State = new InventoryItemState();
    }
}
