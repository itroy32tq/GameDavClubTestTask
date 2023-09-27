using Assets.Script.Interfaces;
using Assets.Script.Item;
using UnityEngine;

namespace PoketZone 
{ 
    public class ItemController: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ItemOnMapInfo _itemOnMap;
        [SerializeField] private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _spriteRenderer.sprite = _itemOnMap.SpriteIcon;
            //ещвщ пока не будем замарачиваться с правильным скейлом
            transform.localScale = Vector3.one * _itemOnMap.Scale;
            _boxCollider.size = _spriteRenderer.size;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ICanTakeItems canTakeItems))
            {
                canTakeItems.TakeItems(_itemOnMap);
                Destroy(gameObject);
            }
        }

    }
}
