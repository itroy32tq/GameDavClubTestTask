using Assets.Script.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class WeaponController : MonoBehaviour
    {
        private WeaponInfo _weapon;
        public WeaponInfo Weapon { get => _weapon;}
        private float _lastShootTime;

        public void ConfigureWeapon(WeaponInfo weapon)
        { 
            _weapon = weapon;
        }

        public virtual void Shoot(Vector2 shootPoint, Vector2 direction)
        {
            float currentTime = Time.time;

            if (currentTime - _lastShootTime > _weapon.ShootInterval)
            {
                var bulletPref = _weapon.Bullet;
                var bullet = Instantiate(bulletPref, shootPoint, Quaternion.identity).GetComponent<Bullet>();
                bullet.Direction = direction;
                _lastShootTime = currentTime;
            }
        }

    }
}
