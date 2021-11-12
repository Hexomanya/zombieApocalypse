using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    private List<SingleNodeBlocker> blockerList = new List<SingleNodeBlocker>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            SingleNodeBlocker nodeBlocker = transform.GetChild(i).GetComponent<SingleNodeBlocker>();
            if (nodeBlocker == null)
            {
                throw new System.ArgumentException($"GameObject {transform.GetChild(i).name} is missing a 'SingleNodeBlocker' Script!");
            }

            blockerList.Add(nodeBlocker);
        }
    }

    void Update()
    {
    }

    public void SpawnActor()
    {

    }

    public void DeleteActor(GameObject gameObject)
    {
        blockerList.Remove(gameObject.GetComponent<SingleNodeBlocker>());
        Destroy(gameObject);
    }

    public List<SingleNodeBlocker> GetNodeBlockers(SingleNodeBlocker exemptBlocker)
    {
        List<SingleNodeBlocker> nodeBlockers = new List<SingleNodeBlocker>(blockerList);
        nodeBlockers.Remove(exemptBlocker);
        return nodeBlockers;
    }
}
