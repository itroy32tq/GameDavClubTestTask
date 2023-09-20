using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public interface IBullet
    {
        void ApplyDamage(ICanBeDamaged canBeDamaged);
    }
}
