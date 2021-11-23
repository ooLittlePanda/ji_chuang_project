using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageCtrl : MonoBehaviour
{
    public Vector3 playerRebirthPosition;
    public Quaternion playerRebirthAngle;
    public string deathType;        

    [SerializeField]
    public int stage = 0;
    [SerializeField]
    public bool stageComplete = false;
    [SerializeField]
    protected string stageName;

    public List<InteractiveObject> interactObjs;
    [SerializeField]
    protected int expectInteractObjsNum = 0;
    public int hasInteractedNum = 0;
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


    public void Rebirth()
    {
        Signal.player.transform.position = playerRebirthPosition;
        Signal.player.transform.rotation = playerRebirthAngle;
        Signal.playerCamera.transform.rotation = Quaternion.identity;
        stageComplete = false;
        resetInteract();
    }

    public void cantInteract()
    {
        for(int i = hasInteractedNum;i<interactObjs.Count;i++)
        {
            interactObjs[i].interactable = false;
        }
    }

    private void resetInteract()
    {
        foreach (var obj in interactObjs)
        {
            obj.interactable = true;
            obj.interactComplete = false;
        }
    }
}
