using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    [field: SerializeField]
    private BodyPartType BodyPartType { get; set; } = BodyPartType.Head;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragHandler dragHandler = eventData.pointerDrag.gameObject.GetComponent<DragHandler>();
            if (dragHandler != null && dragHandler.BodyPartType == BodyPartType)
            {
                eventData.pointerDrag.gameObject.transform.position = gameObject.transform.position;
                dragHandler.wasPlaced = true;
            }
        }
       
    }
}
