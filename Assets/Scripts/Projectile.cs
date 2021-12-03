using Assets.Scripts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float ttl = 5f;
    public float Damage { get; set; } = 0f;
    public Vector3 Direction { get; set; }
    public float Velocity { get; set; }

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
        AttackableObject attackableObject = collision.gameObject.GetComponent<AttackableObject>();
        if (attackableObject != null)
        {
            Vector3 dir = (attackableObject.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.right, dir);
            attackableObject.ApplyDamage(Damage, rotation);
        }

        Destroy(gameObject);
    }
}
