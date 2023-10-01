using Script.Interfaces;
using Script.ItemSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script.Inventoty
{
    public class InventoryWithSlots : IInventory
    {
        public event Action<object, Item, int> OnInventoryItemAddedEvent;
        public event Action<object, string, int> OnInventoryItemRemoveEvent;
        public event Action<object> OnInventoryStateChangedEvent;
        public int Capacity { get; set; }
        public bool IsFull => _slots.All(_slots => _slots.IsFull);
        public IInventorySlot EmptySlot => _slots.Find(slot => slot.IsEmpty);

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
        public Item GetItem(Type itemType)
        {
            return _slots.Find(slots => slots.ItemType == itemType).Item;
        }
        public Item GetItem(string id)
        {
            return _slots.Find(slots => slots.ItemId == id).Item;
        }
        public Item[] GetAllItems()
        {
            var allItems = new List<Item>();
            foreach (var slot in _slots)
            {
                if (!slot.IsEmpty)
                    allItems.Add(slot.Item);
            }
            return allItems.ToArray();
        }
        public Item[] GetAllItems(Type itemType)
        {
            var allItemsOfType = new List<Item>();
            var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
            foreach (var slot in slotsOfType)
            {
                allItemsOfType.Add(slot.Item);
            }
            return allItemsOfType.ToArray();
        }
        public Item[] GetAllItems(string id)
        {
            var allItemsOfId = new List<Item>();
            var slotsOfId = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemId == id);
            foreach (var slot in slotsOfId)
            {
                allItemsOfId.Add(slot.Item);
            }
            return allItemsOfId.ToArray();
        }
        public bool IsPlaceForItem(string id)
        {
            if (EmptySlot != null) return true;
            var slotsOfId = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemId == id);
            return !slotsOfId.All(slot => slot.IsFull);
        }
        public Item[] GetEquippedItems()
        {
            var requiredSlots = _slots.
                FindAll(slot => !slot.IsEmpty && slot.Item.State.IsEquipped);
            var equippedItems = new List<Item>();
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
            foreach (var itemSlot in allItemSlots)
            {
                amount += itemSlot.Amount;
            }
            return amount;
        }
        /// <summary>
        /// попробовать добавить предмет в инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryToAdd(object sender, Item item)
        {
            var slotWithSameItemButNotEmpty = _slots.
                Find(slot => !slot.IsEmpty
                && slot.ItemId == item.Info.Id && !slot.IsFull);

            if (slotWithSameItemButNotEmpty != null)
                return TryAddToSlot(sender, slotWithSameItemButNotEmpty, item);

            if (EmptySlot != null)
                return TryAddToSlot(sender, EmptySlot, item);

            Debug.Log($"Cannot add item ({item.Type}), amount: {item.State.Amount}, " + $"because there is no place for that");

            return false;
        }
        /// <summary>
        /// пробует добавить предмет в слот
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryAddToSlot(object sender, IInventorySlot slot, Item item)
        {
            var fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventarySlot;
            var amountToAdd = fits
                ? item.State.Amount : item.Info.MaxItemsInInventarySlot - slot.Amount;
            var amountLeft = item.State.Amount - amountToAdd;
            var cloneItem = item.Clone();
            cloneItem.State.Amount = amountToAdd;

            if (slot.IsEmpty)
                slot.SetItem((Item)cloneItem);
            else
                slot.Item.State.Amount += amountToAdd;

            Debug.Log($"ItemSpace added to inventory. ItemId: {item.Info.Id}, amount: {amountToAdd}");
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

            if (!toSlot.IsEmpty && fromSlot.ItemId != toSlot.ItemId)
                return;

            var slotCapacity = fromSlot.Capacity;
            var fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
            var amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
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
        public void Remove(object sender, string itemId, int amout = 1)
        {
            var slotsWithItem = GetAllSlots(itemId);
            if (slotsWithItem.Length == 0)
                return;
            var amountToRemove = amout;
            var count = slotsWithItem.Length;

            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];
                if (slot.Amount >= amountToRemove)
                {
                    slot.Item.State.Amount -= amountToRemove;
                    if (slot.Amount <= 0)
                        slot.Clear();

                    Debug.Log($"ItemSpace removed to inventory. ItemId: {itemId}, amount: {amountToRemove}");
                    OnInventoryItemRemoveEvent?.Invoke(sender, itemId, amountToRemove);
                    OnInventoryStateChangedEvent?.Invoke(sender);
                    break;
                }
                var amountRemoved = slot.Amount;
                amountToRemove -= slot.Amount;
                slot.Clear();
                Debug.Log($"ItemSpace removed to inventory. ItemType: {itemId}, amount: {amountRemoved}");
                OnInventoryItemRemoveEvent?.Invoke(sender, itemId, amountRemoved);
                OnInventoryStateChangedEvent?.Invoke(sender);
            }
        }
        public IInventorySlot[] GetAllSlots(string itemId)
        {
            return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemId == itemId).ToArray();
        }
        public bool HasItem(Type type, out Item item)
        {
            item = GetItem(type);
            return item != null;
        }
        public IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }
    }
}