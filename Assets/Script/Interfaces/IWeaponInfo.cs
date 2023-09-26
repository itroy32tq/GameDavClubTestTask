using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IWeaponInfo
    {
        float ShootInterval { get;  }
        GameObject BulletPref { get; }
        string BulletItemId { get; }
    }
}
