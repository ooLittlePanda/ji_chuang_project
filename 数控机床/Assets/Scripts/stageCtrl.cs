using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageCtrl : MonoBehaviour
{
    public Vector3 playerRebirthPosition;
    public Quaternion playerRebirthAngle;

    [SerializeField]
    public int stage = 0;
    [SerializeField]
    public bool stageComplete = false;
    [SerializeField]
    protected string stageName;
    [SerializeField]
    protected List<InteractiveObject> interactObjs;
    [SerializeField]
    protected int expectInteractObjsNum = 0;
    [SerializeField]
    protected int hasInteractedNum = 0;
    private void Start()
    {
        stageName = this.gameObject.name;
        hasInteractedNum = 0;
        initArray();
    }

    protected void initArray()
    {
        interactObjs = new List<InteractiveObject>();
        for(int i =0;i<this.transform.childCount;i++)
        {
            interactObjs.Add(this.transform.GetChild(i).gameObject.GetComponent<InteractiveObject>());
        }
    }

    protected void Rebirth()
    {
        Signal.player.transform.position = playerRebirthPosition;
        Signal.player.transform.rotation = playerRebirthAngle;
        Signal.playerCamera.transform.rotation = Quaternion.identity;
        stageComplete = false;
        foreach(var obj in interactObjs)
        {
            obj.interactable = true;
            obj.interactComplete = false;
        }
    }
}
