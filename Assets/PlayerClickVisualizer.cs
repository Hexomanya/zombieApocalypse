using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickVisualizer : MonoBehaviour
{
    [Header("Objects that need to be disabled")]
    [SerializeField] private GameObject[] objectsNeedToBeDisabled;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (DidClickedOnMap())
            {
                SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.PlayerCommand, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
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
