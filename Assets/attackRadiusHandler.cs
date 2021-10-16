using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRadiusHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<zombieManager>() != null)
        {
            humanMananger hm = this.GetComponentInParent<humanMananger>();
            hm.activated = true;
            hm.currentlyAttacking = collision.gameObject.GetComponent<zombieManager>();
        }
    }
}
