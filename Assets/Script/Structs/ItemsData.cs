using Script.ItemSpace;
using System;
using UnityEngine;

namespace Script.Structs
{
    [Serializable]
    public struct ItemsData
    {
        [Tooltip("описание предмета")]
        public string ItemInfoId;
        [Tooltip("его количество")]
        public int Count;
        public ItemsData(string id, int count)
        {
            ItemInfoId = id; Count = count;
        }
    }
}
