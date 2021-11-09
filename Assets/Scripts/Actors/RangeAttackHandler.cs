using UnityEngine;

public class RangeAttackHandler : MonoBehaviour
{
    [field: SerializeField]
    public GameObject ProjectileSpritePrefab { get; private set; }

    [field: SerializeField]
    public float ProjectileVelocity { get; private set; } = 15f;

    [field: SerializeField]
    public float RangedAttackCooldown { get; private set; } = 3f;

    [field: SerializeField]
    public float Damage { get; private set; } = 4f;

    [field: SerializeField]
    public float Accuracy { get; private set; } = 0.9f;

    public float RangedAttackTimer { get; set; } = 0f;

    public void Shoot(Vector3 direction)
    {
        GameObject go = Instantiate(ProjectileSpritePrefab, transform);
        go.transform.position = transform.position;
        Projectile projectile = go.GetComponent<Projectile>();
        if (projectile == null)
        {
            throw new System.ArgumentNullException($"Prefab {ProjectileSpritePrefab.name} is missing a 'Projectile' Script!");
        }

        float f = 360f * Random.Range(0f, 1f - Accuracy);
        f -= f / 2f;
        direction += Quaternion.Euler(0f, 0f, f) * direction;

        projectile.Direction = direction;
        projectile.Damage = Damage;
        projectile.Velocity = ProjectileVelocity;
    }
}
