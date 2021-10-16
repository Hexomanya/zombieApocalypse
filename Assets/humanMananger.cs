using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanMananger : MonoBehaviour
{
    public float health = 10f;
    public float damage = 2f;
    public float velocity = 2f;
    public int humanType = 0;
    public Vector3 safePos = new Vector3 (0, 500, 0);

    bool isFleeing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(isFleeing)
        {
            Vector3 offset = new Vector3(this.transform.position.x - safePos.x, this.transform.position.y - safePos.y, 0);
            this.transform.position -= offset.normalized * Time.deltaTime * velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HumanCollide");
        if (collision.gameObject.GetComponent<zombieManager>() != null)
        {
            isFleeing = true;
            Debug.Log("Run");
        }
    }
}
