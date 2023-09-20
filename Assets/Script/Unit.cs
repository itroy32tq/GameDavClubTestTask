using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class Unit : MonoBehaviour, ICanBeDamaged, ICanBeMover
    {

        [SerializeField, Range(1f, 10f)] private float _speed = 1f;
        [SerializeField, Range(1f, 20f)] private int _health;
        [SerializeField] private Rigidbody2D _rigidbody;

        protected readonly Vector3[] Directions = new[]
        {
            Vector3.right, Vector3.up, Vector3.left, Vector3.down
        };

        private int _currentHealth;
        public int Health { get => _currentHealth; protected set => _currentHealth = value; }

        protected Rigidbody2D RigidBody => _rigidbody;
        protected float Speed => _speed;
        protected int Facing = 1;
        protected EMode Mode = EMode.idle;

        protected virtual void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0) Destroy(gameObject);
        }

        public void MakeMove(int facing)
        {
            _rigidbody.velocity = Directions[facing] * _speed;
        }
    }
}
