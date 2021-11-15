using UnityEngine;

[CreateAssetMenu(fileName = "New BodyPart", menuName = "BodyPart")]
public class BodyPart : ScriptableObject
{
    new public string name = "New BodyPart";

    public Sprite sprite = null;

    public BodyPartType Type;

    public int damageModifier;

    public int healthModifier;

    public int speedModifier;

    public int intelligenceModifier;

    public void AttachToSelectedZombie()
    {
        Horde.instance.AttachBodyPartToSelectedZombie(this);
    }

}
