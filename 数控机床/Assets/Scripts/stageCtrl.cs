using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageCtrl : MonoBehaviour
{
    [SerializeField]
    public bool stageComplete = false;
    [SerializeField]
    private string stageName;
    [SerializeField]
    private List<InteractiveObject> interactObjs;

    private void Start()
    {
        stageName = this.gameObject.name;
        initArray();
    }

    private void Update()
    {
        if(interactObjs[interactObjs.Count - 1].interactComplete)
        {
            stageComplete = true;
        }
    }

    private void initArray()
    {
        interactObjs = new List<InteractiveObject>();
        for(int i =0;i<this.transform.childCount;i++)
        {
            interactObjs.Add(this.transform.GetChild(i).gameObject.GetComponent<InteractiveObject>());
        }
    }
}
