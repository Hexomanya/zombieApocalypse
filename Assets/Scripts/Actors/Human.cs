using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Human : MonoBehaviour
    {
        public float moveSpeed = 3f;
        public float meleeDamage = 5f;
        public float attackCooldown = 2f;
        public HumanTypes typ = HumanTypes.Fleeing;

        private float AttackTimer { get; set; } = 0f;
        private Vector3 TargetMovePosition { get; set; }
        private Rigidbody2D Rb { get; set; }
        private DetectionHandler DetectionHandler { get; set; }
        private bool fleeing = false;
    
        void Start()
        {
            Rb = gameObject.GetComponent<Rigidbody2D>();
            DetectionHandler = GetComponentInChildren<DetectionHandler>();
        }

        void Update()
        {
            if (DetectionHandler.GetTargetPositionWithLoS() == transform.position && !fleeing)
            {
                return;
            }
        
            if(typ == HumanTypes.Fleeing)
            {
                fleeing = true;
                // TODO: get nearest safe position from pathfinder 
                Vector3 direction = Vector3.up * 500f - transform.position;
                direction = Utility.RemoveNumberFractions(direction);
                direction.z = 0f;
            
                // TODO: maybe change to rigidbody
                transform.position += direction.normalized * Time.deltaTime * moveSpeed;
            }
        }
    }
}
