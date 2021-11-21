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
                Debug.Log(Signal.interactingObj);
                if (Signal.interactingObj == interactObjs[theoryInteractObj].gameObject)
                {
                    theoryInteractObj++;
                    hasInteractedNum++;
                }
                else
                {
                    Rebirth();
                    hasInteractedNum = 0;
                    theoryInteractObj = 0;
                }
                Signal.interactingObj = null;
            }
        }
    }
}
