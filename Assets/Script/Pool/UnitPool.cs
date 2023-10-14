using Assets.Script.Factory;
using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Pool
{
    public class UnitPool<Unit> : CustomPool<Unit> where Unit : MonoBehaviour
    {
        public UnitPool(IFactory<Unit> factory, int count) : base(factory, count)
        {
        }
    }
}
