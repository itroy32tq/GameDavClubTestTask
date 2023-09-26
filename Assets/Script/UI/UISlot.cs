using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.UI
{
    public class UISlot : MonoBehaviour, IDropHandler
    {
        public virtual void OnDrop(PointerEventData eventData)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
        }
    }
}
