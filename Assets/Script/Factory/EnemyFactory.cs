using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Factory
{
    public abstract class EnemyFactory : MonoBehaviour, IUnitFactoryMethod<Enemy>
    {
        public abstract Enemy CreateUnit();
        
    }
}
