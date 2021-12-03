using Pathfinding;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public abstract class ActorManagerBase : MonoBehaviour
    {
        public List<SingleNodeBlocker> blockerList = new List<SingleNodeBlocker>();
        protected List<GameObject> deleteList = new List<GameObject>();
        protected EndScreenPopup endScreenPopup;

        public virtual void Awake()
        {
            endScreenPopup = FindObjectOfType<EndScreenPopup>();
        }

        public virtual void Start()
        {
            InitializeNodeBlocker();
        }

        public virtual void Update()
        {
            foreach (GameObject item in deleteList.ToList())
            {
                if(!item.GetComponentInChildren<BloodManager>().IsBloodEffectPlaying())
                {
                    deleteList.Remove(item);
                    Destroy(item);
                }                
            }
        }

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

        public abstract void ActorDied(GameObject gameObject);

        public void DeleteActor(GameObject gameObject)
        {
            blockerList.Remove(gameObject.GetComponent<SingleNodeBlocker>());
            deleteList.Add(gameObject);
        }

        public List<SingleNodeBlocker> GetNodeBlockers(SingleNodeBlocker exemptBlocker)
        {
            List<SingleNodeBlocker> nodeBlockers = new List<SingleNodeBlocker>(blockerList);
            nodeBlockers.Remove(exemptBlocker);
            return nodeBlockers;
        }
    }
}
