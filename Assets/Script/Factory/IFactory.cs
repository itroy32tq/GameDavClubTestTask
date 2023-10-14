using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Factory
{
    public interface IFactory<out T> where T : MonoBehaviour
    {
        T Create();
    }
}
