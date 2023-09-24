using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace PoketZone
{
    public class Player : Unit
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private VariableJoystick _joystick;
        [SerializeField] private Button _shootButton;
       
        private Weapon _currentWeapon;

        protected override void Start()
        {
            //todo
            base.Start();
            _shootButton.onClick.AddListener(OnShootButtonClick);
            _currentWeapon = _weapons[0];
            
        }

        private void OnShootButtonClick()
        {
            _currentWeapon.Shoot(_shootPoint);
        }

        private void Update() 
        {

            MakeMove(_joystick.Direction);

        }
    }
}
