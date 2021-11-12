using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasGroup))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public BodyPart bodyPart;

    public bool WasPlaced { get; set; } = false;

    private CanvasGroup canvasGroup;

    private Vector3 dragStartingPosition;

    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

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
        if(WasPlaced)
        {
            Debug.Log("Placed: " + bodyPart.name);
            inventory.RemoveBodyPart(bodyPart);
            //Place BodyPart on Zombie
        }
        else
        {
            gameObject.transform.position = dragStartingPosition;
        }
    }

}
