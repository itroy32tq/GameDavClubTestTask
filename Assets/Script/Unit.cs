using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PoketZone
{
    public abstract class Unit : MonoBehaviour, ICanBeDamaged, ICanBeMover
    {

        [SerializeField, Range(1f, 10f)] private float _speed = 1f;
        [SerializeField, Range(1f, 20f)] private int _health;
        [SerializeField] private Rigidbody2D _rigidbody;
        private List<SpriteRenderer> _spriteRenderers;

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

        protected virtual void Awake()
        {
            //todo костыль, по лучше иметь одни спрайт с изображением юнита
            SpriteRenderer maineRenderer;
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
            if (TryGetComponent<SpriteRenderer>(out maineRenderer)) _spriteRenderers.Add(maineRenderer);
        }
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
            if (direction.x < 0) FlipUnit(true);
            if (direction.x > 0) FlipUnit(false);
            _rigidbody.velocity = direction * _speed;

        }

        private void FlipUnit(bool flip)
        {
            foreach (var render in _spriteRenderers)
            { 
                render.flipX = flip;
            }
        }
    }
}
