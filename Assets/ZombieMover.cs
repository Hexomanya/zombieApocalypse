using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour
{
    // THIS SCRIPT IS TEMPORARY
    private AIDestinationSetter setter;

    void Start()
    {
        setter = this.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setter.target.position = mousePos;
        }
    }
}
