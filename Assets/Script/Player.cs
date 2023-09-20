using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class Player : Unit
    {

        [SerializeField] private List<Weapon> _weapons;

        [SerializeField] private Transform _shootPoint;

        private Weapon _currentWeapon;

        protected override void Start()
        {
            base.Start();
            _currentWeapon = _weapons[0];
            
        }

        private void Update() 
        {
            if (Input.GetMouseButton(0))
            {
                _currentWeapon.Shoot(_shootPoint);
            }
        }
    }
}
