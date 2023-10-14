using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Factory
{
    public class UnitFactory : IFactory<Unit>
    {
        private readonly Unit _prefab;
        private readonly Transform _container;

        public UnitFactory(Unit prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
        }

        public Unit Create()
        {
            return UnityEngine.Object.Instantiate(_prefab, _container);
        }
    }
}
