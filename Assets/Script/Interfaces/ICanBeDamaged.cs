
using System;

namespace Assets.Script.Interfaces
{
    public interface ICanBeDamaged
    {
        void TakeDamage(int damage);

        public event Action<int, int> OnUnitHealtChanged;
    }
}
