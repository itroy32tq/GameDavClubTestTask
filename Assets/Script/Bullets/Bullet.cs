using Assets.Script.Interfaces;
using UnityEngine;

namespace PoketZone
{
    public class Bullet : MonoBehaviour, ICanApplyDamage
    {
        [SerializeField, Range(1f, 6f)] private int _damage;
        [SerializeField, Range(1f, 10f)] private float _speed;
        [SerializeField] Rigidbody2D _rigidbody;
        [SerializeField, Range(1f, 50f)] float _lifeTime = 12f;

        private Vector2 _direction = Vector2.left;
        public Vector2 Direction { get => _direction; set => _direction = value; }

        private void Start()
        {
            _rigidbody.velocity = _direction * _speed;
            Destroy(gameObject, _lifeTime);
        }

        public void ApplyDamage(ICanBeDamaged canBeDamaged)
        {
            canBeDamaged.TakeDamage(_damage);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ICanBeDamaged unit))
            { 
                ApplyDamage(unit);
                Destroy(gameObject);
            }
        }
    }
}
