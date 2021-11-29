using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonLinearStageCtrl : stageCtrl
{
    void Update()
    {
        if(Signal.currentStage == stage)
        {
            if(hasInteractedNum == expectInteractObjsNum)
            {
                stageComplete = true;
            }
            if(Signal.interactingObj!=null)
            {
                hasInteractedNum++;
                Signal.interactingObj = null;
            }
        }
    }
}
