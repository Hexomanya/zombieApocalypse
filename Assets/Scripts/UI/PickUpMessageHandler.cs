using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpMessageHandler : MonoBehaviour
{
    public GameObject messagePrefab;
    public float messageDropSpeed = 200f;
    public List<PickUpMessage> messages = new List<PickUpMessage>();

    public static PickUpMessageHandler Instance { get; private set; }

    private float height;

    void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
        height = transform.parent.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in messages.ToList())
        {
            item.TTL -= Time.deltaTime;
            if (item.TTL <= 0f)
            {
                messages.Remove(item);
                Destroy(item.gameObject);
            }
        }

        for (int i = 0; i < messages.Count; i++)
        {
            float targetY = messages[i].Height / 2f;
            for (int j = 0; j <= i; j++)
            {
                targetY += messages[j].Height;
            }

            if (targetY < messages[i].transform.position.y)
            {
                messages[i].transform.position += Vector3.down * Time.deltaTime * messageDropSpeed;
            }
            else
            {
                messages[i].transform.position = new Vector3(messages[i].transform.position.x, targetY, 0f);
            }
        }
    }

    public void AddNewMessage(string text)
    {
        GameObject go = Instantiate(messagePrefab, transform);
        PickUpMessage pickUpMessage = go.GetComponent<PickUpMessage>();
        if(pickUpMessage == null)
        {
            throw new System.ArgumentException("Message Prefab is missing a 'PickUpMessage' Script!");
        }

        pickUpMessage.Height = go.GetComponent<RectTransform>().rect.height;
        pickUpMessage.SetText(text);
        go.transform.position = new Vector3(0f, height - (pickUpMessage.Height / 2f), 0f);
        go.GetComponent<RectTransform>().offsetMax = messagePrefab.GetComponent<RectTransform>().offsetMax;
        go.GetComponent<RectTransform>().offsetMin = messagePrefab.GetComponent<RectTransform>().offsetMin;
        messages.Add(go.GetComponent<PickUpMessage>());
    }
}
