using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class GameManager : MonoBehaviour 
    {
        public static GameManager Instance;
        private void Awake()
        {
            Instance = this;
        }

        private void Start () 
        { 
          
        }
    }
}
