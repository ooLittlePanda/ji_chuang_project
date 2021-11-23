using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    StageIntegralCtrl sic;
    Animator cameraAnim;

    private void Start()
    {
        sic = GetComponent<StageIntegralCtrl>();
        cameraAnim = Signal.cameraAnim;
        Debug.Log(cameraAnim.gameObject.name);
    }

    private void Update()
    {
        if(Signal.death)
        {
            deathAnim(sic.stages[Signal.currentStage].deathType);
            Signal.death = false;
        }
    }

    private void deathAnim(string deathType)
    {
        cameraAnim.SetBool(deathType, true);
    }
}
