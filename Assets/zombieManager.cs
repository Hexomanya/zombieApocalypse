using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    public float velocity = 1.5f;
    public float damage = 5f;
    public float attackTimeout = 2f;

    Vector3 mousePos;
    bool isAttacking;
    humanMananger currentlyAttacking;
    float currentAttackTimeout = 0f;


    private void Start()
    {
        mousePos = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("Attack");
                currentlyAttacking.health -= damage;
                currentAttackTimeout = attackTimeout;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentlyAttacking = collision.gameObject.GetComponent<humanMananger>();
        isAttacking = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttacking = false;
    }
}
