using System;

namespace Script.Interfaces
{
    public interface ICanBeDamaged
    {
        void TakeDamage(int damage);

        event Action<int, int> OnUnitHealtChangedEvent;
    }
}
