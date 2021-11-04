using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject head;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftFoot;
    public GameObject rightFoot;

    void Start()
    {
        float change = Random.Range(0, 1);
        if(change > 0.5)
        {
            this.head = null;
        }
        change = Random.Range(0, 1);
        if(change > 0.5)
        {
            this.leftArm = null;
        }
        change = Random.Range(0, 1);
        if(change > 0.5)
        {
            this.rightArm = null;
        }
        change = Random.Range(0, 1);
        if(change > 0.5)
        {
            this.leftFoot = null;
        }
        change = Random.Range(0, 1);
        if(change > 0.5)
        {
            this.rightFoot = null;
        }
    }

    public void InstantiateWithBodyParts(Transform transform)
    {
        Instantiate(this, transform);
        if (head != null)
        {
            Instantiate(head, transform);
        }
        if (leftArm != null)
        {
            Instantiate(leftArm, transform);
        }
        if (rightArm != null)
        {
            Instantiate(rightArm, transform);
        }
        if (leftFoot != null)
        {
            Instantiate(leftFoot, transform);
        }
        if (rightFoot != null)
        {
            Instantiate(rightFoot, transform);
        }
    }
    
}
