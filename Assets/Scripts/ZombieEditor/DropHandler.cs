using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public BodyPartType BodyPartType;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragHandler dragHandler = eventData.pointerDrag.gameObject.GetComponent<DragHandler>();
            if (dragHandler != null && dragHandler.bodyPart.Type == BodyPartType)
            {
                eventData.pointerDrag.gameObject.transform.position = gameObject.transform.position;
                dragHandler.WasPlaced = true;
                eventData.pointerDrag.gameObject.transform.SetParent(gameObject.transform);
                // Place BodyPart on selected Zombie
                dragHandler.bodyPart.PlaceOnZombie();
            }
        }
       
    }
}
