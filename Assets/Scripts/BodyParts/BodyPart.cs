using UnityEngine;

[CreateAssetMenu(fileName = "New BodyPart", menuName = "BodyPart")]
public class BodyPart : ScriptableObject
{
    new public string name = "New BodyPart";

    public Sprite sprite = null;

    public BodyPartType type;

    public ZombieType zombieType;

    public float meleeDamageModifier = 0f;

    public float meleeCooldownTime = 0f;

    public float healthModifier = 0f;

    public float speedModifier = 0f;

    public float intelligenceModifier = 0f;

    public float detectionRange = 0f;

    public bool AttachToSelectedZombie()
    {
        return Horde.instance.AttachBodyPartToSelectedZombie(this);
    }

    public BodyPart New()
    {
        BodyPart bodyPart = CreateInstance<BodyPart>();
        bodyPart.name = name;
        bodyPart.sprite = sprite;
        bodyPart.meleeDamageModifier = meleeDamageModifier;
        bodyPart.meleeCooldownTime = meleeCooldownTime;
        bodyPart.type = type;
        bodyPart.healthModifier = healthModifier;
        bodyPart.speedModifier = speedModifier;
        bodyPart.intelligenceModifier = intelligenceModifier;
        bodyPart.detectionRange = detectionRange;

        return bodyPart;
    }

}
