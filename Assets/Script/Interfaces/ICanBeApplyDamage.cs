using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public interface ICanApplyDamage
    {
        void ApplyDamage(ICanBeDamaged canBeDamaged);
    }
}
