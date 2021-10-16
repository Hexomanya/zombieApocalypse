using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour, IHumanoid
{
    public float velocity = 1.5f;
    public float damage = 5f;
    public float attackTimeout = 2f;

    public float maxHealth { get; set; } = 20f;
    public float currentHealth { get; set; }

    Vector3 mousePos;
    bool isAttacking;
    humanMananger currentlyAttacking;
    float currentAttackTimeout = 0f;


    private void Start()
    {
        mousePos = this.transform.position;
        this.currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
       if(Input.GetMouseButtonDown(0))
        {
           mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Pressed");
        }
        Vector3 offset = new Vector3(this.transform.position.x - mousePos.x, this.transform.position.y - mousePos.y, 0);
        this.transform.position -= offset.normalized * Time.deltaTime * velocity;

        if(isAttacking)
        {
            currentAttackTimeout -= Time.deltaTime;
            if(currentAttackTimeout <= 0)
            {
                Debug.Log("Zombie Attack");
                if (currentlyAttacking != null)
                {
                    currentlyAttacking.currentHealth -= damage;
                    currentAttackTimeout = attackTimeout;
                }
                else
                {
                    isAttacking = false;
                }  
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Vector3.Distance(this.transform.position, collision.gameObject.transform.position) <= 1.5)
        {
            currentlyAttacking = collision.gameObject.GetComponent<humanMananger>();
            isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentlyAttacking != null) 
        { 
            if(currentlyAttacking == collision.gameObject.GetComponent<humanMananger>())
            {
                isAttacking = false;
            }
        }   
    }
}
