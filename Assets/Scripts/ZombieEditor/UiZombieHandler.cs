using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiZombieHandler : MonoBehaviour
{
    public BodyPartManager bodyPartManager;


    public void InitializeUI()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i< bodyPartManager.currentBodyParts.Length; i++)
        {
            switch(i)
            {

                case (int) BodyPartType.Head:
                    if (bodyPartManager.currentBodyParts[i] != null)
                    {
                        //DO STUFF
                    }
                    break;

                case (int)BodyPartType.LeftArm:
                    break;

                case (int)BodyPartType.RightArm:
                    break;

                case (int)BodyPartType.LeftFoot:
                    break;

                case (int)BodyPartType.RightFoot:
                    break;

            }
        }
    }
}
