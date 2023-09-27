using Script.Interfaces;
using System;

namespace Script.Structs
{
    [Serializable]
    public struct ItemState : IItemState
    {
        private int _itemAmount;
        private bool _isEquipped;
        private bool _isOnMap;

        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
        public int Amount { get => _itemAmount; set => _itemAmount = value; }
        public bool IsOnMap { get => _isOnMap; set => _isOnMap = value; }
    }
}

