using System;
using UnityEngine;

namespace Assets.Script.Structs
{
    [Serializable]
    public struct FilingInventoryData
    {
        [Tooltip("описание предмета")]
        public ItemInfo ItemInfo;
        [Tooltip("его количество")]
        public int Count;
        public FilingInventoryData(ItemInfo itemInfo, int count)
        {
            ItemInfo = itemInfo; Count = count;
        }
    }
}
