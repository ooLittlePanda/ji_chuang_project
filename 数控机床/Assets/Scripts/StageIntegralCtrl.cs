using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIntegralCtrl : MonoBehaviour
{
    [SerializeField]
    stageCtrl[] stages;

    private void Start()
    {
        Signal.currentStage = Signal.MinStage;
    }

    private void Update()
    {
        if(Signal.currentStage>Signal.MaxStage)
        {
            End();
        }
        else if(stages[Signal.currentStage].stageComplete == true)
        {
            Signal.currentStage++;
        }
    }

    private void End()
    {

    }
}
