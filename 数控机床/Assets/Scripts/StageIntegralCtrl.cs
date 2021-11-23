using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIntegralCtrl : MonoBehaviour
{
    [SerializeField]
    public stageCtrl[] stages;

    private void Awake()
    {
        Signal.player = FindObjectOfType<CharacterController>().gameObject;
        Signal.playerCamera = FindObjectOfType<Camera>().gameObject;
        Signal.cameraAnim = FindObjectOfType<Camera>().gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        Signal.currentStage = Signal.MinStage;
        stages[0].playerRebirthPosition = Signal.player.transform.position;
        stages[0].playerRebirthAngle = Signal.player.transform.rotation;
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
            if(Signal.currentStage<=Signal.MaxStage)
            {
                stages[Signal.currentStage].playerRebirthPosition = Signal.player.transform.position;
                stages[Signal.currentStage].playerRebirthAngle = Signal.player.transform.rotation;
            }
        }
    }

    private void End()
    {
        Debug.Log("All stages Complete");
    }
}
