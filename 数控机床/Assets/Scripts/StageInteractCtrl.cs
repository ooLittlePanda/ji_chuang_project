using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInteractCtrl : MonoBehaviour
{
    [SerializeField]
    private string[] stageName;

    [SerializeField]
    List<GameObject>[] stageInteractiveObj;

    private void Start()
    {
        Signal.Stage = Signal.MinStage;
        stageInteractiveObj = new List<GameObject>[stageName.Length];
        initList();
    }

    private void Update()
    {
        if(Signal.Stage<=Signal.MaxStage)
        {
            if (Signal.stageComplete[Signal.Stage] == stageInteractiveObj[Signal.Stage].Count)
            {
                Signal.Stage++;
            }
        }
    }

    private void initList()
    {
        for(int i = 0;i<stageName.Length;i++)
        {
            stageInteractiveObj[i] = new List<GameObject>();
            //Transform[] stageTrans = GameObject.Find(stageName[i]).GetComponentsInChildren<Transform>();
            GameObject stage = GameObject.Find(stageName[i]);
            for(int j = 0;j<stage.transform.childCount; j++)
            {
                stageInteractiveObj[i].Add(stage.transform.GetChild(j).gameObject);
                Debug.Log(stage.transform.GetChild(j).gameObject.name);
            }
        }
    }
}
