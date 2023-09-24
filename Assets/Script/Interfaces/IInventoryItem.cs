using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInventoryItem
{
    IInventoryItemInfo Info { get; }
    IInventoryItemState State { get; }
    Type Type { get; }
    IInventoryItem Clone();
}
public interface IInventoryItemInfo
{
    string Id { get; }
    string Title { get; }
    string Description { get; }
    int MaxItemsInInventarySlot { get; }

    Sprite SpriteIcon { get; }

}

public interface IInventoryItemState
{
    bool IsEquipped { get; set; }
    int Amount { get; set; }

}

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
