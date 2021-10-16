using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanMananger : MonoBehaviour, IHumanoid
{
    public float damage = 2f;
    public float velocity = 2f;
    public int humanType = 0;
    public Vector3 safePos = new Vector3 (0, 500, 0);
    public float attackTimeout = 2f;
    public bool activated = false;
    public GameObject enteredZombie;
    public float searchRadius = 5f;
    public zombieManager currentlyAttacking;

    float currentAttackTimeout = 0f;
    

    public float maxHealth { get; set;} = 20f;
    public float currentHealth { get; set;}

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    { 
        if (!activated) { return; }
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if(humanType == 0)
        {
            Vector3 offset = new Vector3(this.transform.position.x - safePos.x, this.transform.position.y - safePos.y, 0);
            this.transform.position -= offset.normalized * Time.deltaTime * velocity;
        }

        if (humanType == 1)
        {
            if (enteredZombie != null) 
            {
                Vector3 offset = new Vector3(this.transform.position.x - enteredZombie.transform.position.x, this.transform.position.y - enteredZombie.transform.position.y, 0);
                this.transform.position -= offset.normalized * Time.deltaTime * velocity;
            }
            if (currentlyAttacking != null)
            {
                currentAttackTimeout -= Time.deltaTime;
                if (currentAttackTimeout <= 0)
                {
                    Debug.Log("Human Attack");
                    currentlyAttacking.currentHealth -= damage;
                    currentAttackTimeout = attackTimeout;
                }
            }
        }

        if (humanType == 2)
        {
            if (enteredZombie != null)
            {
                Vector3 offset = new Vector3(this.transform.position.x - enteredZombie.transform.position.x, this.transform.position.y - enteredZombie.transform.position.y, 0);
                this.transform.position -= offset.normalized * Time.deltaTime * velocity;
            }

            if(currentlyAttacking != null)
            {
                currentAttackTimeout -= Time.deltaTime;
                if (currentAttackTimeout <= 0)
                {
                    Debug.Log("Human Attack");
                    currentlyAttacking.currentHealth -= damage;
                    currentAttackTimeout = attackTimeout;
                }
            }
        }
    }

   

}
