using Assets.Scripts;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private AttackableObject attackableObject;

    // Start is called before the first frame update
    void Start()
    {
        attackableObject = GetComponentInParent<AttackableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(attackableObject.CurrentHealth / attackableObject.MaxHealth, transform.localScale.y, 0) ;
    }
}
