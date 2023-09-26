using Assets.Script.Interfaces;
using System;

namespace Script.Inventoty
{
    [Serializable]
    public class InventoryItemState : IInventoryItemState
    {
        public int itemAmount;
        public bool isItemEquipped;
        public bool IsEquipped { get => isItemEquipped; set => isItemEquipped = value; }
        public int Amount { get => itemAmount; set => itemAmount = value; }
        public InventoryItemState() { itemAmount = 0; isItemEquipped = false; }
    }
}
