using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInteractCtrl : MonoBehaviour
{
    [SerializeField]
    private AllinteractiveObjList AIOL;
    [SerializeField]
    private int[] numofStageCorrectInteractiveObj;

    [SerializeField]
    List<GameObject>[] stageInteractiveObj;
    //List<GameObject> stageInteractiveObj;
    private void Start()
    {
        Signal.Stage = Signal.MinStage;
        //numofStageCorrectInteractiveObj = new int[Signal.StageCount];
        AIOL = this.GetComponent<AllinteractiveObjList>();
        initList();
    }

    private void Update()
    {
        if(Signal.Stage<=Signal.MaxStage)
        {
            if (Signal.stageComplete[Signal.Stage] == stageInteractiveObj[Signal.Stage].Count)
            {
                Signal.Stage++;
                Debug.Log(111);
            }
        }
    }

    private void initList()
    {
        stageInteractiveObj = new List<GameObject>[numofStageCorrectInteractiveObj.Length];
        int k = 0;
        for (int i = 0; i < numofStageCorrectInteractiveObj.Length; i++)
        {
            stageInteractiveObj[i] = new List<GameObject>();
            for (int j = 0; j < numofStageCorrectInteractiveObj[i]; j++)
            {
                stageInteractiveObj[i].Add(AIOL.allInteractiveObjList[k]);
                k++;
            }
        }
    }
}
