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
        private int dirHeld = -1;

        private readonly Vector3[] directions = new Vector3[]
        {
            Vector3.right, Vector3.up, Vector3.left, Vector3.down
        };

        private readonly KeyCode[] keys = new KeyCode[]
        {
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow
        };

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
            if (Input.GetMouseButton(0))
            {
                _currentWeapon.Shoot(_shootPoint);
            }
            
            //todo для проверки передвижения
            for (int i = 0; i < 4; i++)
            {
                if (Input.GetKey(keys[i])) dirHeld = i;
            }

            if (dirHeld == -1) return;
            else
            {
                MakeMove(directions[dirHeld]);
            }
        }
    }
}
