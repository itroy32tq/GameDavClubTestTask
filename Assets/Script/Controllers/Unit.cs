using Script.Interfaces;
using System;
using UnityEngine;

namespace PoketZone
{
    public abstract class Unit : MonoBehaviour, ICanBeDamaged, ICanBeMover
    {

        [SerializeField, Range(1f, 10f)] private float _speed = 1f;
        [SerializeField, Range(1f, 20f)] private float _health;
        [SerializeField] private Rigidbody2D _rigidbody;

        private float _currentHealth;

        public event Action<float, float> OnUnitHealtChangedEvent;

        public float Health { get => _currentHealth; protected set => _currentHealth = value; }

        protected Rigidbody2D RigidBody => _rigidbody;
        public float Speed { get => _speed; protected set => _speed = value; }
        protected Vector2 Faceing { get; set; } = Vector2.right;

        public event Action<Unit> OnUnitDiesEvent;

        protected virtual void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            OnUnitHealtChangedEvent?.Invoke(_currentHealth, _health);
            if (Health <= 0)
            {
                Destroy(gameObject);
                OnUnitDiesEvent?.Invoke(this);
            }
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
