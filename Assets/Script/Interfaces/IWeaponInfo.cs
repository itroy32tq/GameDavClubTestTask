using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IWeaponInfo
    {
        float ShootInterval { get;  }
        GameObject BulletPref { get; }
        InventoryItemInfo BulletItem { get; }
    }
}
