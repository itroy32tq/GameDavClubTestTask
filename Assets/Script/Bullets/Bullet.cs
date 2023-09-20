using UnityEngine;

namespace PoketZone
{
    public class Bullet : MonoBehaviour, ICanApplyDamage
    {
        [SerializeField, Range(1f, 6f)] private int _damage;
        [SerializeField, Range(1f, 10f)] private float _speed;

        private Vector2 _direction = Vector2.left;

        public void ApplyDamage(ICanBeDamaged canBeDamaged)
        {
            canBeDamaged.TakeDamage(_damage);
        }

        private void Update()
        {
            //todo логика полета, надо подумать в зависимости от направления
            transform.Translate(_direction * _speed * Time.deltaTime);
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
