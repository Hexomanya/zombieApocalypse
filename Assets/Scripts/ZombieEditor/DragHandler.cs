using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [field: SerializeField]
    public BodyPartType BodyPartType { get; set; } = BodyPartType.Head;

    public bool wasPlaced = false;

    private CanvasGroup canvasGroup;

    private Vector3 dragStartingPosition;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        dragStartingPosition = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position += new Vector3(eventData.delta.x, eventData.delta.y,1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if(!wasPlaced)
        {
            gameObject.transform.position = dragStartingPosition;
        }
    }

}
