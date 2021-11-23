using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearStageCtrl : stageCtrl
{
    private int theoryInteractObj = 0;

    private void Update()
    {
        if(Signal.currentStage == stage)
        {
            if (hasInteractedNum == expectInteractObjsNum)
            {
                stageComplete = true;
            }
            if (Signal.interactingObj != null)
            {
                if (Signal.interactingObj == interactObjs[theoryInteractObj].gameObject)
                {
                    theoryInteractObj++;
                    hasInteractedNum++;
                }
                else
                {
                    Signal.death = true;
                    Signal.cantInput();
                    cantInteract();
                    hasInteractedNum = 0;
                    theoryInteractObj = 0;
                }
                Signal.interactingObj = null;
            }
        }
    }
}
