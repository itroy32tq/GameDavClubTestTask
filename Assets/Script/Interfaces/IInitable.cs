using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IInitable
    {
        public void OnInit<T>(T initializer);
    }
}
