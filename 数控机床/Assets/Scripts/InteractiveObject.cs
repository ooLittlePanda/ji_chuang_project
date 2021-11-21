using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class InteractiveObject: MonoBehaviour
{
    [SerializeField]
    private int interactStage = 0;
    public bool interactable = true;
    public bool interactComplete = false;
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Material originMat;

    [SerializeField]
    private Material highLightMat;

    [SerializeField]
    private float distance = 4.0f;
    private void Start()
    {
        interactStage = this.transform.parent.gameObject.GetComponent<stageCtrl>().stage;
        meshRenderer = this.GetComponent<MeshRenderer>();
        interactable = true;
        interactComplete = false;
        EnableHighLight(false);
    }

    private void Update()
    {
        if(Signal.currentStage!=interactStage)
        {
            interactable = false;
        }
        else
        {
            if(interactComplete == false)
            {
                interactable = true;
            }
        }
    }
    private void EnableHighLight(bool on_off)
    {
        if(meshRenderer!=null&&originMat!=null&&highLightMat!=null)
        {
            if(Vector3.Distance(this.transform.position,Signal.player.transform.position)<distance)
            {
                meshRenderer.material = on_off ? highLightMat : originMat;
            }
            else
            {
                meshRenderer.material = originMat;
            }
        }
    }

    private void OnMouseOver()
    {
        if(interactable)
        {
            EnableHighLight(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable = !interactable;
                interactComplete = true;
                Signal.interactingObj = this.gameObject;
            }
        }
        else
        {
            EnableHighLight(false);
        }
    }

    private void OnMouseExit()
    {
        if (interactable)
        {
            EnableHighLight(false);
        }
    }
}
