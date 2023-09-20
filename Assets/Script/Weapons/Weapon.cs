using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _label;
        [SerializeField] private Sprite _icon;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] protected Bullet Bullet;

        private void Awake()
        {
            _spriteRenderer.sprite = _icon;
        }
        public abstract void Shoot(Transform shootPoint);
    }
}
