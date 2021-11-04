using Assets.Scripts.Actors;
using UnityEngine;

public class StateDisplay : MonoBehaviour
{
    private IActor actor;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        actor = gameObject.GetComponentInParent<IActor>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = actor.CurrentState.StateName;
    }
}
