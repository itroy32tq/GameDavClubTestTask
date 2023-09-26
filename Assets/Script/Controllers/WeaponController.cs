using Assets.Script.Weapons;
using UnityEngine;
using Assets.Script.Interfaces;

namespace PoketZone
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] UIInventory _uiInventory;
        private int _bulletsCount;
        private ItemInfo _bulletItem;
        private WeaponInfo _weapon;
        public WeaponInfo Weapon { get => _weapon;}

        private float _lastShootTime;

        public void ConfigureWeapon(WeaponInfo weapon)
        { 
            _weapon = weapon;
            _uiInventory.Inventory.OnInventoryItemAddedEvent += OnInventoryItemAdded;
            _bulletItem = _weapon.BulletItem;
        }

        private void OnInventoryItemAdded(object sender, IInventoryItem item, int amount)
        {
            if (item.Info.Id != _weapon.BulletItem.Id) return;
            _bulletsCount += amount;
        }

        public virtual void Shoot(Vector2 shootPoint, Vector2 direction)
        {

            if (_bulletsCount == 0)
            {
                Debug.Log("кончились патроны");
                return;
            }
            float currentTime = Time.time;

            if (currentTime - _lastShootTime > _weapon.ShootInterval)
            {
                var bulletPref = _weapon.BulletPref;
                var bullet = Instantiate(bulletPref, shootPoint, Quaternion.identity).GetComponent<Bullet>();

                bullet.Direction = direction;
                _lastShootTime = currentTime;
                _uiInventory.Inventory.Remove(this, _bulletItem.Id);
            }
        }

    }
}
