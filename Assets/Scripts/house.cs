using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{

    public List<humanMananger> humans = new List<humanMananger>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<zombieManager>() != null) 
        {
            foreach (var item in humans)
            {
                item.activated = true;
                item.enteredZombie = collision.gameObject;
            }
        } 
    }
}
