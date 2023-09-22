using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace PoketZone
{
    public class Player : Unit
    {

        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private VariableJoystick _joystick;
       
        private Weapon _currentWeapon;

        protected override void Start()
        {
            //todo
            base.Start();
            _currentWeapon = _weapons[0];
            
        }

        private void Update() 
        {
            //todo
            //if (Input.GetMouseButton(0)) _currentWeapon.Shoot(_shootPoint);


            if (_joystick.Direction == Vector2.zero) MakeMove(Vector2.zero);
            MakeMove(_joystick.Direction);

        }
    }
}
