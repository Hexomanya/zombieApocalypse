using Assets.Scripts.Actors;
using UnityEngine;

[CreateAssetMenu(fileName = "New BodyPart", menuName = "BodyPart")]
public class BodyPart : ScriptableObject
{
    new public string name = "New BodyPart";

    public Sprite sprite = null;

    public BodyPartType Type;

    public int intelligenceModifier;

    public int damageModifier;

    public int speedModifier;

    public void PlaceOnZombie()
    {
        var zombie = Horde.instance.GetSelectedZombie();
        zombie.GetComponent<BodyPartManager>().AttachBodyPart(this);
    }

}
