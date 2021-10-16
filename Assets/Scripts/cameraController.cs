using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float velocity = 2f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position -= Vector3.left * velocity * Time.deltaTime;
        }

    }
}
