using UnityEngine;

[CreateAssetMenu(fileName = "New BodyPart", menuName = "BodyPart")]
public class BodyPart : ScriptableObject
{
    new public string name = "New BodyPart";

    public Sprite sprite = null;

    public BodyPartType Type;

    public float damageModifier = 0f;

    public float healthModifier = 0f;

    public float speedModifier = 0f;

    public float intelligenceModifier = 0f;

    public void AttachToSelectedZombie()
    {
        Horde.instance.AttachBodyPartToSelectedZombie(this);
    }

}
