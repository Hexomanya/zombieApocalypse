using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public abstract class ActorManagerBase : MonoBehaviour
    {
        protected List<SingleNodeBlocker> blockerList = new List<SingleNodeBlocker>();

        protected void InitializeNodeBlocker()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                SingleNodeBlocker nodeBlocker = transform.GetChild(i).GetComponent<SingleNodeBlocker>();
                if (nodeBlocker == null)
                {
                    throw new System.ArgumentException($"GameObject {transform.GetChild(i).name} is missing a 'SingleNodeBlocker' Script!");
                }

                if (!blockerList.Contains(nodeBlocker))
                {
                    blockerList.Add(nodeBlocker);
                }
            }
        }

        public void ActorDied(GameObject gameObject)
        {
            // TODO: Drop BodyParts
            DeleteActor(gameObject);
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
}
