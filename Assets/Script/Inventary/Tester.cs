using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester
{
    private IInventory _inventory;
    [SerializeField] private int _inventaryCapacity = 10;

    private IInventoryItemInfo _appleInfo;
    private IInventoryItemInfo _pepperInfo;
    private UIInventorySlot[] _uislot;

    public InventoryWithSlots Inventory { get; }

    public Tester(IInventoryItemInfo appleInfo, 
        IInventoryItemInfo pepperInfo, 
        UIInventorySlot[] uiSlots) 
    { 
        _appleInfo = appleInfo; _pepperInfo = pepperInfo; _uislot = uiSlots;

        Inventory = new InventoryWithSlots(15);
        Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
    }

    private void OnInventoryStateChanged(object sender)
    {
        foreach (var slot in _uislot) 
        { 
            slot.Refresh();
        }
    }

    public void FillSlots()
    { 
        var allSlots = Inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;
        for (int i = 0; i < filledSlots; i++)
        { 
            var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);

            filledSlot = AddRandomPepperIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
        }
        SetupInventoryUI(Inventory);
    }
    private IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = UnityEngine.Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = UnityEngine.Random.Range(1, 4);
        var apple = new Apple(_appleInfo);
        apple.State.Amount = rCount;
        Inventory.TryAddToSlot(this, rSlot, apple);
        return rSlot;
    }
    private IInventorySlot AddRandomPepperIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = UnityEngine.Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = UnityEngine.Random.Range(1, 4);
        var pepper = new Pepper(_pepperInfo);
        pepper.State.Amount = rCount;
        Inventory.TryAddToSlot(this, rSlot, pepper);
        return rSlot;
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
    { 
        var allSlots = Inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        { 
            var slot = allSlots[i];
            var uiSlot = _uislot[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }
}
