using System;
using UnityEngine;

namespace Script.ItemSpace
{
    [Serializable]
    public class ItemsData
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
