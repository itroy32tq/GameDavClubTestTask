using Script.Interfaces;
using Script.ItemSpace;
using UnityEngine;

namespace PoketZone 
{ 
    public class ItemController: MonoBehaviour
    {
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider;
        private Item _item;
        public Item ItemOnMap { get => _item; set => _item = value; }
        private void Awake()
        {
            if (_item != null)
            {
                _spriteRenderer.sprite = _item.Info.SpriteIcon;
                //пока не будем замарачиваться с правильным скейлом
                transform.localScale = Vector3.one * _item.Info.Scale;
                _boxCollider.size = _spriteRenderer.size;
            }
        }
        public void Init(Item item)
        {
            _item = item;
            _boxCollider.isTrigger = true;
            Awake();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ICanTakeItem canTakeItem))
            {
                if (canTakeItem.TryTakeItem(_item)) Destroy(gameObject);
            }
        }
    }
}
