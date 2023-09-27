using Script.Interfaces;
using UnityEngine;

namespace Script.ItemSpace
{
    [CreateAssetMenu(fileName = "ItemInfo", menuName = "Configurations/ItemInfo")]
    public class ItemInfo : ScriptableObject, IItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _maxItemsInInventarySlot;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _scale;
        [SerializeField] private float _shootInterval;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private string _bulletItemId;

        public string Id { get => _id; }
        public string Title { get => _title; }
        public string Description { get => _description; }
        public int MaxItemsInInventarySlot { get => _maxItemsInInventarySlot; }
        public Sprite SpriteIcon { get => _icon; }
        public float Scale { get => _scale; }
        public float ShootInterval { get => _shootInterval; }
        public GameObject BulletPref { get => _bulletPref; }
        public string BulletItemId { get => _bulletItemId; }
    }
}
