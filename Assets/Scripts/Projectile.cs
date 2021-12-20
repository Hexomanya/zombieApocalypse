using Assets.Scripts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask zombieLayer;

    private float ttl = 5f;
    public float Damage { get; set; } = 0f;
    public Vector3 Direction { get; set; }
    public float Velocity { get; set; }


    private void Start()
    {
        Quaternion rotation = Quaternion.LookRotation(Direction.normalized);
        rotation.x = this.transform.rotation.x;
        rotation.y = this.transform.rotation.y;
        this.transform.rotation = rotation;
    }

    void Update()
    {
        transform.position += Direction.normalized * Time.deltaTime * Velocity;

        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Because it collides with Visuals now
        GameObject actualZombie = collision.transform.parent.gameObject;

        if(actualZombie != null)
        {
            AttackableObject attackableObject = actualZombie.GetComponent<AttackableObject>();
            if (attackableObject != null)
            {
                Debug.Log("Did " + Damage + " Point of damage Damage with bullet");
                Vector3 dir = (attackableObject.transform.position - transform.position).normalized;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.right, dir);
                attackableObject.ApplyDamage(Damage, rotation);
            }
        }

        Destroy(gameObject);
    }
}
