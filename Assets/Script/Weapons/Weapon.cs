using Script.ItemSpace;
using System;

namespace Assets.Script
{
    public class Weapon
    {
        Item WeaponInfo { get; }
        Type Type => GetType();

        public void LoadWeapon() 
        { 
            
        }

        public Weapon(Item weaponInfo)
        {
            WeaponInfo = weaponInfo;
        }
    }
}
