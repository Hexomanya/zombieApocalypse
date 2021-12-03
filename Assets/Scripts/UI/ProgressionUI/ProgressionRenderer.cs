using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionRenderer : MonoBehaviour
{
    [SerializeField] private GameObject[] mapMarkers;
    [SerializeField] private GameObject[] connectingLines = new GameObject[3];
    [SerializeField] private PopUpMessageHandler messageHandler;

    private Level[] levels;

    private void Start()
    {
        levels = LevelProgression.instance.Levels;

        if(mapMarkers.Length != levels.Length)
        {
            Debug.LogError("The number of map markers and levels are not the same!");
            return;
        }

        ActivateMapMarkers();
        DrawConnectingLine();

        if (GameManager.Instance.AllLevelsComplete)
        {
            messageHandler.ShowMessage("Congratulations! You completed all Levels and insured the downfall of humanity! You can now replay all levels!");
        }
    }

    private void ActivateMapMarkers()
    {
        for (int i = 0; i < mapMarkers.Length; i++)
        {
            if (levels[i].Locked)
            {
                if (levels[i].Completed)
                {
                    PopUpHandler handler = mapMarkers[i].GetComponentInChildren<PopUpHandler>(true);
                    handler.Deactivate();
                }
                else
                {
                    mapMarkers[i].SetActive(false);
                }
            }
        }
    }

    private void DrawConnectingLine()
    {
        for (int i = 0; i < connectingLines.Length; i++)
        {
            if (levels[i].Completed && levels[i + 1].Completed || levels[i].Completed && !levels[i + 1].Locked)
            {
                connectingLines[i].gameObject.SetActive(true);
            }
            else
            {
                connectingLines[i].gameObject.SetActive(false);
            }
        }
    }
}
