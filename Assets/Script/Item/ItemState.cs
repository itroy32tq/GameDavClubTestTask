using Script.Interfaces;
using System;

namespace Script.ItemSpace
{
    [Serializable]
    public class ItemState : IItemState
    {
        private int _itemAmount;
        private bool _isEquipped;
        private bool _isOnMap;

        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
        public int Amount { get => _itemAmount; set => _itemAmount = value; }
        public bool IsOnMap { get => _isOnMap; set => _isOnMap = value; }

        public ItemState(int itemAmount = 1, bool isEquiped = false, bool isOnMap = false) 
        {
            _itemAmount = itemAmount; _isEquipped = isEquiped; _isOnMap = isOnMap;
        }
    }
}

