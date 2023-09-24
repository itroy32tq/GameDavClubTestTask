using System.Collections.Generic;
using UnityEngine;

public class InventoryWithSlotsService
{
    
    private List<UIInventorySlot> _uiSlotList;

    List<BaseInventoryData> _baseItems;

    public InventoryWithSlots Inventory { get; }
    public InventoryWithSlotsService(List<UIInventorySlot> uiSlotList, List<BaseInventoryData> baseItems) 
    {
        _uiSlotList = uiSlotList;
        _baseItems = baseItems;

        Inventory = new InventoryWithSlots(uiSlotList.Count);
        FillSlots();
        Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
    }

    private void OnInventoryStateChanged(object sender)
    {
        foreach (var slot in _uiSlotList) 
        { 
            slot.Refresh();
        }
    }
    /// <summary>
    /// переносим предметы и их количество из конфигурации в инвентарь
    /// </summary>
    public void FillSlots()
    { 

        foreach (var baseItem in _baseItems) 
        {
            var item = new InventoryItem(baseItem.itemInfo);
            item.State.Amount = baseItem.count;
            if (!Inventory.TryToAdd(this, item))
                Debug.Log("не удалось добавить предметы из конфигурации в инвентарь");
        }
        SetupInventoryUI(Inventory);
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
    { 
        var allSlots = Inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        { 
            var slot = allSlots[i];
            var uiSlot = _uiSlotList[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }
}
