using System;

namespace Script.Interfaces
{
    public interface ICanBeDamaged
    {
        void TakeDamage(float damage);

        event Action<float, float> OnUnitHealtChangedEvent;
    }
}
