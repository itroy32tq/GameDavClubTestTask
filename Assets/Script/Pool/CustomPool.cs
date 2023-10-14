using Assets.Script.Factory;
using PoketZone;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Pool
{
    public abstract class CustomPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private List<T> _pool;
        private readonly Transform _container;
        private readonly IFactory<T> _factory;
        public T Prefab { get => _prefab; }
        public List<T> Pool { get => _pool; }
        public bool AutoExpand { get; set; }
        public Transform Container { get => _container; }

        public IFactory<T> Factory { get => _factory; }

        public CustomPool(IFactory<T> factory, int count) 
        {
            _factory = factory;
            CreatePool(count);
        }
        private void CreatePool(int count)
        {
            _pool = new List<T>();
            for (int i = 0; i < count; i++)
                Create();
        }
        
        public T Create(bool isActivByDefault = false)
        {
            var createdObject = _factory.Create();
            createdObject.gameObject.SetActive(isActivByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            element = _pool.FirstOrDefault(x => !x.isActiveAndEnabled);
            element?.gameObject.SetActive(true);
            return element != null;
        }
        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;
            if (AutoExpand)
                return Create(true);
            else throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
        }

        public void Release(T obj)
        { 
            obj.gameObject.SetActive(false);
        }

        
    }
}
