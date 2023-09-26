
using System;

namespace Assets.Script.Interfaces
{
    public interface ICanBeDamaged
    {
        void TakeDamage(int damage);

        event Action<int, int> OnUnitHealtChangedEvent;
    }
}
