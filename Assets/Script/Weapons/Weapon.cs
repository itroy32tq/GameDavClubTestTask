using Assets.Script.Interfaces;
using Assets.Script.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    public class Weapon
    {
        IWeaponInfo WeaponInfo { get; }
        Type Type => GetType();

        public void LoadWeapon() 
        { 
            
        }

        public Weapon(WeaponInfo weaponInfo)
        {
            WeaponInfo = weaponInfo;
        }
    }
}
