using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class Player : MonoBehaviour, ICanBeDamaged
    {
        [SerializeField, Range(1f, 20f)] private int _health;

        [SerializeField] private List<Weapon> _weapons;

        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Rigidbody2D _rigidbody;

        private Weapon _currentWeapon;

        private int _currentHealth;
        public int Health => _currentHealth;

        private void Start()
        {
            _currentWeapon = _weapons[0];
            _currentHealth = _health;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
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
