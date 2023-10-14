using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Pool
{
    public class CustomPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private List<T> _pool;
        private readonly Transform _container;
        public T Prefab { get => _prefab; }
        public List<T> Pool { get => _pool; }
        public bool AutoExpand { get; set; }
        public Transform Container { get => _container; }

        
        public CustomPool(T prefab, int count, Transform container = null) 
        {
            _prefab = prefab;
            _container = container;
            CreatePool(count);

        }
        private void CreatePool(int count)
        {
            _pool = new List<T>();
            for (int i = 0; i < count; i++)
                CreateObject();
        }
        private T CreateObject(bool isActivByDefault = false)
        { 
            var createdObject = Object.Instantiate(_prefab, _container);
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
                return CreateObject(true);
            else throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
        }

        public void Release(T obj)
        { 
            obj.gameObject.SetActive(false);
        }
    }
}
