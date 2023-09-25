using System.Collections.Generic;
using UnityEngine;

public class InventoryWithSlotsService
{
    
    private List<UIInventorySlot> _uiSlotList;

    public InventoryWithSlots Inventory { get; }
    public InventoryWithSlotsService(List<UIInventorySlot> uiSlotList) 
    {
        _uiSlotList = uiSlotList;

        Inventory = new InventoryWithSlots(_uiSlotList.Count);
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
    public void FillSlots(List<BaseInventoryData> baseItems)
    { 

        foreach (var baseItem in baseItems) 
        {
            var item = new InventoryItem(baseItem.itemInfo);
            item.State.Amount = baseItem.count;
            if (!Inventory.TryToAdd(this, item))
                Debug.Log("не удалось добавить предметы из конфигурации в инвентарь");
        }
        SetupInventoryUI(Inventory);
    }
    /// <summary>
    /// удаляем элемент по клику на кнопку из инвентаря
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="uiitem"></param>
    public void TryRemoveItemOnClick(object sender, UIItem uiitem)
    {
        Inventory.Remove(sender, ((UIInventoryItem)uiitem).Item.Info.Id);
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
