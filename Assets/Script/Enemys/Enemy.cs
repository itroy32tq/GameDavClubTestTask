using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class Enemy : Unit
    {
        [SerializeField] private string _name;
        [SerializeField, Range(1f,10f)] int _reward;
        
        //todo
        [SerializeField] private Player _target;

        protected int Reward => _reward;
    }
}
