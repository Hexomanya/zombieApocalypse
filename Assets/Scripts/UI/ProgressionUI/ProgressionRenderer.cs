using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProgressionRenderer : MonoBehaviour
{
    [SerializeField] private GameObject[] mapMarkers;

    private Level[] levels;
    private LineRenderer lineRenderer;

    private void Start()
    {
        levels = LevelProgression.instance.Levels;
        lineRenderer = this.GetComponent<LineRenderer>();

        if(mapMarkers.Length != levels.Length)
        {
            Debug.LogError("The number of map markers and levels are not the same!");
            return;
        }

        ActivateMapMarkers();
        DrawConnectingLine();
        
    }

    private void ActivateMapMarkers()
    {
        for (int i = 0; i < mapMarkers.Length; i++)
        {
            if (levels[i].Locked)
            {
                mapMarkers[i].SetActive(false);
            }
        }
    }

    private void DrawConnectingLine()
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = 0; i < mapMarkers.Length; i++)
        {
            if (levels[i].Locked)
            {
                //Vector3 pos = mapMarkers[i].GetComponent<RectTransform>().transform.position;
                positions.Add(mapMarkers[i].transform.position);
            }
        }

        if (positions.Count > 1)
        {
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
        }
        else
        {
            Destroy(lineRenderer);
        }
    }
}
