using Assets.Scripts.Actors;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanManager : ActorManagerBase
{
    [SerializeField] private bool debugSkipWon = true;

    public void Update()
    {
        if (transform.childCount == 0 || debugSkipWon)
        {
            endScreenPopup.LevelWon();

            string sceneName = SceneManager.GetActiveScene().name;
            LevelProgression.instance.GetLevelByName(sceneName).Completed = true;
            Destroy(this);
        }
    }

    public override void ActorDied(GameObject gameObject)
    {
        foreach (var item in Horde.instance.availableBodyParts)
        {
            if (item.type == BodyPartType.Torso)
            {
                continue;
            }

            float roll = Random.Range(0f, 1f);
            if (roll <= GameManager.Instance.BodyPartDropChance)
            {
                BodyPart bodyPart = item.New();
                Inventory.instance.AddNewBodyPart(bodyPart);
                InGameUi.instance.ShowBodyPartCollectedPopUp(bodyPart);
                // Old System
                //PickUpMessageHandler.Instance.AddNewMessage(bodyPart.name);
            }
        }

        DeleteActor(gameObject);   
    }
}
