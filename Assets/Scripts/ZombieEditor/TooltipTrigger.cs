using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BodyPart bodyPart;

    public BodyPartManager zombie;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string content = "";
        zombie = GetComponent<UiZombieHandler>()?.BodyPartManager;
        if(GetComponentsInChildren<DragHandler>()?.Length > 0)
        {
            if (bodyPart != null)
            {
                content = $"Damage: +{bodyPart.meleeDamageModifier}\nAttackCooldown: {bodyPart.meleeCooldownTime}\nHealth: +{bodyPart.healthModifier}\n";
                content += $"Speed: +{bodyPart.speedModifier}\nIntelligence: +{bodyPart.intelligenceModifier}\nSight: +{bodyPart.detectionRange}";

                Tooltip.instance?.ShowTooltip(bodyPart.name, content);
            }
        }
        else if (zombie != null)
        {
            var stats = zombie.GetAllBodyPartStatModifiers();
            content = $"Damage: +{stats.MeleeDamageModifier}\nAttackCooldown: {stats.MeleeCooldownTime}\nHealth: +{stats.HealthModifier}\n";
            content += $"Speed: +{stats.SpeedModifier}\nIntelligence: +{stats.IntelligenceModifier}\nSight: +{stats.DetectionRange}";
            Tooltip.instance?.ShowTooltip("Zombie", content);
        }
           
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.instance?.HideTooltip();
    }
}
