using Assets.Script.Interfaces;
using UnityEngine;

namespace Assets.Script.Weapons
{
    [CreateAssetMenu(fileName = "WeaponInfo", menuName = "Configurations/Inventory/InventoryItemInfo/Weapon")]
    public class WeaponInfo : InventoryItemInfo, IWeaponInfo
    {

        [SerializeField] private float _shootInterval;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private InventoryItemInfo _bulletItem;

        public float ShootInterval { get => _shootInterval; }
        public GameObject BulletPref { get => _bulletPref;  }

        public InventoryItemInfo BulletItem { get => _bulletItem; }

    }
}
