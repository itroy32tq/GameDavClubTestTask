using Assets.Script.Interfaces;
using UnityEngine;

namespace Assets.Script.Weapons
{
    [CreateAssetMenu(fileName = "WeaponInfo", menuName = "Configurations/WeaponInfo")]
    public class WeaponInfo : ItemInfo, IWeaponInfo
    {
        [SerializeField] private float _shootInterval;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private string _bulletItemId;

        public float ShootInterval { get => _shootInterval; }
        public GameObject BulletPref { get => _bulletPref;  }
        public string BulletItemId  {get => _bulletItemId; }
    }
}
