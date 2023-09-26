using Assets.Script.Weapons;
using UnityEngine;
using Assets.Script.Interfaces;
using Script.UI;

namespace PoketZone
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] UIInventory _uiInventory;
        private int _bulletsCount;
        private string _bulletItemId;
        private WeaponInfo _weapon;
        public WeaponInfo Weapon { get => _weapon;}

        private float _lastShootTime;

        public void ConfigureWeapon(WeaponInfo weapon)
        { 
            _weapon = weapon;
            _uiInventory.InventoryModel.OnInventoryItemAddedEvent += OnInventoryItemAdded;
            _bulletItemId = _weapon.BulletItemId;
        }

        private void OnInventoryItemAdded(object sender, IInventoryItem item, int amount)
        {
            if (item.Info.Id != _bulletItemId) return;
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
                var bullet = Instantiate(bulletPref, shootPoint, Quaternion.identity).GetComponent<BulletController>();

                bullet.Direction = direction;
                _lastShootTime = currentTime;
                _uiInventory.InventoryModel.Remove(this, _bulletItemId);
            }
        }

    }
}
