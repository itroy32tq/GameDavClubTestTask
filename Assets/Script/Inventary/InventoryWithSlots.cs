using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryWithSlots : IInventory
{
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemoveEvent;
    public event Action<object> OnInventoryStateChangedEvent;
    public int Capacity { get ; set ; }
    public bool IsFull => _slots.All(_slots => _slots.IsFull);

    private List<IInventorySlot> _slots;

    public InventoryWithSlots(int capacity) 
    { 
        Capacity = capacity;
        _slots = new List<IInventorySlot>();
        for (int i = 0; i < Capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slots => slots.ItemType == itemType).Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty)
                allItems.Add(slot.Item);
        }
        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
        foreach (var slot in slotsOfType)
        {
            allItemsOfType.Add(slot.Item);
        }
        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.
            FindAll(slot => !slot.IsEmpty && slot.Item.State.IsEquipped);
        var equippedItems = new List<IInventoryItem>();
        foreach (var slot in requiredSlots)
        { 
            equippedItems.Add(slot.Item);
        }
        return equippedItems.ToArray();
    }

    public int GetItemAmout(Type itemType)
    {
        var amount = 0;
        var allItemSlots = _slots.
            FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
        foreach(var itemSlot in allItemSlots)
        {
            amount+= itemSlot.Amount;
        }
        return amount;
    }
    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.
            Find(slot => !slot.IsEmpty 
            && slot.ItemType == item.Type && !slot.IsFull);

        if (slotWithSameItemButNotEmpty != null)
            return TryAddToSlot(sender, slotWithSameItemButNotEmpty, item);

        var emptySlot = _slots.Find(slot => slot.IsEmpty);

        if (emptySlot != null) 
            return TryAddToSlot(sender, emptySlot, item);

        Debug.Log($"Cannot add item ({item.Type}), amount: {item.State.Amount}, " + $"because there is no place for that");

        return false;
    }
    public bool TryAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)  
    {
        var fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventarySlot;
        var amountToAdd = fits
            ? item.State.Amount : item.Info.MaxItemsInInventarySlot - slot.Amount;
        var amountLeft = item.State.Amount - amountToAdd;
        var cloneItem = item.Clone();
        cloneItem.State.Amount = amountToAdd;

        if (slot.IsEmpty)
            slot.SetItem(cloneItem);
        else
            slot.Item.State.Amount += amountToAdd;

        Debug.Log($"Item added to inventory. ItemType: {item.Type}, amount: {amountToAdd}");
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangedEvent?.Invoke(sender);

        if (amountLeft <= 0)
            return true;

        item.State.Amount = amountLeft;

        return TryToAdd(sender, item); 
    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    { 
        if (fromSlot.IsEmpty)
            return;

        if (toSlot.IsFull)
            return;

        if (!toSlot.IsEmpty && fromSlot.ItemType != toSlot.ItemType)
            return;

        var slotCapacity = fromSlot.Capacity;
        var fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
        var amountToAdd = fits? fromSlot.Amount : slotCapacity - toSlot.Amount;
        var amountLeft = fromSlot.Amount - amountToAdd;

        if (toSlot.IsEmpty)
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
            OnInventoryStateChangedEvent?.Invoke(sender);
        }

        toSlot.Item.State.Amount += amountToAdd;

        if (fits)
            fromSlot.Clear();
        else 
        {
            fromSlot.Item.State.Amount = amountLeft;
        }
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public void Remove(object sender, Type itemType, int amout = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)
            return;
        var amountToRemove = amout;
        var count = slotsWithItem.Length;

        for (int i = count-1; i >=0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.Amount >= amountToRemove) 
            { 
                slot.Item.State.Amount -= amountToRemove;
                if (slot.Amount <=0)
                    slot.Clear();

                Debug.Log($"Item removed to inventory. ItemType: {itemType}, amount: {amountToRemove}");
                OnInventoryItemRemoveEvent?.Invoke(sender, itemType, amountToRemove);
                OnInventoryStateChangedEvent?.Invoke(sender);
                break;
            }
            var amountRemoved = slot.Amount;
            amountToRemove -= slot.Amount;
            slot.Clear();
            Debug.Log($"Item removed to inventory. ItemType: {itemType}, amount: {amountRemoved}");
            OnInventoryItemRemoveEvent?.Invoke(sender, itemType, amountRemoved);
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
    }
    public IInventorySlot[] GetAllSlots(Type itemType)
    { 
        return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
    }
    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }

    public IInventorySlot[] GetAllSlots()
    { 
        return _slots.ToArray();
    }

}
