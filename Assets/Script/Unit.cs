using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace PoketZone
{
    public abstract class Unit : MonoBehaviour, ICanBeDamaged, ICanBeMover
    {

        [SerializeField, Range(1f, 10f)] private float _speed = 1f;
        [SerializeField, Range(1f, 20f)] private int _health;
        [SerializeField] private Rigidbody2D _rigidbody;

        private int _currentHealth;
        public int Health { get => _currentHealth; protected set => _currentHealth = value; }

        protected Rigidbody2D RigidBody => _rigidbody;
        protected float Speed => _speed;
        protected Vector2 Faceing { get; set; } = Vector2.right;

        protected virtual void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0) Destroy(gameObject);
        }
            
        public void MakeMove(Vector2 direction)
        {
            if (direction.x < 0)
            {
                Vector3 rotate = transform.eulerAngles;
                rotate.y = 180;
                transform.rotation = Quaternion.Euler(rotate);
                Faceing = Vector2.left;
            }
            if (direction.x > 0)
            {
                Vector3 rotate = transform.eulerAngles;
                rotate.y = 0;
                transform.rotation = Quaternion.Euler(rotate);
                Faceing = Vector2.right;
            } 
            _rigidbody.velocity = direction * _speed;

        }
    }
}
