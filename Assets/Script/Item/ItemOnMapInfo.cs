using Assets.Script.Interfaces;
using UnityEngine;

namespace Assets.Script.Item
{
    [CreateAssetMenu(fileName = "ItemOnMapInfo", menuName = "Configurations/ItemOnMapInfo")]
    public class ItemOnMapInfo : ItemInfo, IItemOnMap
    {
        [SerializeField] private float _scale;
        [SerializeField] private int _count;
        public float Scale { get => _scale; }
        public int CountOnMap { get =>_count; } 
        public ItemOnMapInfo() 
        {
            _count = 1;
        }
    }
}
