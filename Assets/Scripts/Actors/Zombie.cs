using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Zombie : MonoBehaviour
    {
        public float moveSpeed = 3f;
        public float concentrationTime = 10f;

        private float ConcentrationTimer { get; set; }= 0f;
        private Vector3 TargetMovePosition { get; set; }
        private Rigidbody2D Rb { get; set; }

        void Awake()
        {
            Rb = gameObject.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector3 direction = TargetMovePosition - transform.position;
            direction = Utility.RemoveNumberFractions(direction);
            direction.z = 0f;

            // Target reached
            if(direction == Vector3.zero)
            {
                ConcentrationTimer = 0f;
            }
        
            // TODO: maybe change to rigidbody
            transform.position += direction.normalized * Time.deltaTime * moveSpeed;

            if (Input.GetMouseButtonDown(0))
            {
                TargetMovePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ConcentrationTimer = concentrationTime;
            }

            if (ConcentrationTimer <= 0f)
            {
                // Get a possible target inside detection Range
                TargetMovePosition = gameObject.GetComponentInChildren<DetectionHandler>().GetTargetPositionWithLoS();
                ConcentrationTimer = concentrationTime;
            }

            ConcentrationTimer -= Time.deltaTime;
        }
    }
}
