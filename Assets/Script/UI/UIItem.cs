using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI
{

    public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _removeItemButton;
        private GridLayoutGroup _gridLayoutGroup;
        private Canvas _maineCanvas;

        public event Action<object, UIItem> OnUIItemRemoveButtonClickEvent;

        private void Start()
        {
            _removeItemButton.gameObject.SetActive(false);
            _removeItemButton.onClick.AddListener(OnRemoveItemButtonClick);
            _maineCanvas = GetComponentInParent<Canvas>();
            _gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
        }

        private void OnRemoveItemButtonClick()
        {
            OnUIItemRemoveButtonClickEvent?.Invoke(_removeItemButton, this);
            _removeItemButton.gameObject.SetActive(false);
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_gridLayoutGroup.enabled) _gridLayoutGroup.enabled = false;

            var slotTransform = _rectTransform.parent;
            slotTransform.SetAsLastSibling();
            //todo если успею сделаю другое решение
            _canvasGroup.blocksRaycasts = false;
        }
        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _maineCanvas.scaleFactor;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_removeItemButton.gameObject.activeInHierarchy)
                _removeItemButton.gameObject.SetActive(true);
            else _removeItemButton.gameObject.SetActive(false);
        }
    }
}
