using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    float maxHealth;
    float currentHealth;
    bool isHuman;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponentInParent<humanMananger>() != null)
        {
            maxHealth = this.gameObject.GetComponentInParent<humanMananger>().maxHealth;
            isHuman = true;
        }
        else
        {
            maxHealth = this.gameObject.GetComponentInParent<zombieManager>().maxHealth;
            isHuman = false;
        }
          
    }

    // Update is called once per frame
    void Update()
    {
        if (isHuman)
        {
            currentHealth = this.gameObject.GetComponentInParent<humanMananger>().currentHealth;
        }
        else
        {
            currentHealth = this.gameObject.GetComponentInParent<zombieManager>().currentHealth;
        }
        this.transform.localScale = new Vector3(currentHealth / maxHealth, this.transform.localScale.y, 0) ;
    }
}
