using Script.ItemSpace;
using System;
using UnityEngine;

namespace Script.Structs
{
    [Serializable]
    public struct ItemsData
    {
        [Tooltip("описание предмета")]
        public ItemInfo ItemInfo;
        [Tooltip("его количество")]
        public int Count;
        public ItemsData(ItemInfo itemInfo, int count)
        {
            ItemInfo = itemInfo; Count = count;
        }
    }
}
