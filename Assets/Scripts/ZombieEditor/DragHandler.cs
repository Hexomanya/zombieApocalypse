using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public BodyPart bodyPart;

    private Image image;

    public bool WasPlaced { get; set; } = false;

    private CanvasGroup canvasGroup;

    private Vector3 dragStartingPosition;

    private Inventory inventory;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        image = gameObject.GetComponentInChildren<Image>();
    }

    private void Start()
    {
        inventory = Inventory.instance;
        image.sprite = bodyPart.sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        dragStartingPosition = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if(WasPlaced)
        {
            inventory.RemoveBodyPart(bodyPart);
        }
        else
        {
            gameObject.transform.position = dragStartingPosition;
        }
    }

}
