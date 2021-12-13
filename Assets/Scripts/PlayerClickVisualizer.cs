using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickVisualizer : MonoBehaviour
{
    public static PlayerClickVisualizer Instance;

    [Header("Marker Settings")]
    [SerializeField] private GameObject clickMarkerObject;

    [Header("Objects that need to be disabled")]
    [SerializeField] private GameObject[] objectsNeedToBeDisabled;

    private List<GameObject> currentlyMovingObjects = new List<GameObject>();

    private Vector3 currentMarkedPos = Vector3.zero;
    private GameObject currentMarker;
    private float currentMarkerTimer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void MarkNewPosition(GameObject zombie, Vector3 mousePos)
    {
        //Check if click was on ui element like tutorial
        if (DidClickedOnMap())
        {
            //Register all zombies so you can remove marker when no one is moving to marker anymore.
            currentlyMovingObjects.Add(zombie);

            if (mousePos != currentMarkedPos)
            {
                currentMarkedPos = mousePos;

                CreateMarker(currentMarkedPos);

                SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.PlayerCommand, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }

    public void RemoveZombie(GameObject zombie)
    {
        currentlyMovingObjects.Remove(zombie);

        if(currentlyMovingObjects.Count <= 0)
        {
            DestroyMarker();
        }
    }

    private void CreateMarker(Vector3 createPos)
    {
        if(currentMarker != null)
        {
            Destroy(currentMarker);
        }

        currentMarker = Instantiate(clickMarkerObject, createPos, Quaternion.Euler(0, 0, 0), this.transform);
    }

    private void DestroyMarker()
    {
        Destroy(currentMarker);
        currentlyMovingObjects.Clear();
    }

    private bool DidClickedOnMap()
    {
        if(objectsNeedToBeDisabled == null) { return true; }

        foreach (GameObject obj in objectsNeedToBeDisabled)
        {
            if(obj != null)
            {
                if (obj.activeSelf)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
