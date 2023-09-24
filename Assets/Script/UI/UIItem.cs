using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    private GridLayoutGroup _gridLayoutGroup;
    private Canvas _maineCanvas;

    private void Start()
    {
        _maineCanvas = GetComponentInParent<Canvas>();
        _gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
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
}
