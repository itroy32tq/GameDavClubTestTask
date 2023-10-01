using Script.UI;
using System.Collections.Generic;

namespace Script.Inventoty
{
    public class InventoryStateUpdater
    {
        private List<UIInventorySlot> _uiSlotList;
        public InventoryStateUpdater(List<UIInventorySlot> uiSlotList)
        {
            _uiSlotList = uiSlotList;
            
        }
        public void OnInventoryStateChanged(object sender)
        {
            foreach (var slot in _uiSlotList)
            {
                slot.Refresh();
            }
        }
    }
}
