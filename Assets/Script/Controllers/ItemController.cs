using Assets.Script.Interfaces;
using Assets.Script.Item;
using UnityEngine;

namespace PoketZone 
{ 
    public class ItemController: MonoBehaviour
    {
        [SerializeField] private ItemOnMapInfo _itemOnMap;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider;
        public ItemOnMapInfo ItemOnMap { get => _itemOnMap; set => _itemOnMap = value; }

        private void Awake()
        {
            if (_itemOnMap != null)
            {
                _spriteRenderer.sprite = _itemOnMap.SpriteIcon;
                //пока не будем замарачиваться с правильным скейлом
                transform.localScale = Vector3.one * _itemOnMap.Scale;
                _boxCollider.size = _spriteRenderer.size;
            }
        }
        public void Init(ItemOnMapInfo itemOnMap)
        {
            _itemOnMap = itemOnMap;
            Awake();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ICanTakeItem canTakeItem))
            {
                canTakeItem.TakeItem(_itemOnMap);
                Destroy(gameObject);
            }
        }

    }
}
