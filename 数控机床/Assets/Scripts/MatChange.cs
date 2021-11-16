using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class MatChange : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Material originMat;

    [SerializeField]
    private Material highLightMat;

    [SerializeField]
    private float distance = 4.0f;

    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<CharacterController>().gameObject;
        meshRenderer = this.GetComponent<MeshRenderer>();
        EnableHighLight(false);
    }

    private void EnableHighLight(bool on_off)
    {
        if(meshRenderer!=null&&originMat!=null&&highLightMat!=null)
        {
            if(Vector3.Distance(this.transform.position,player.transform.position)<distance)
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
        EnableHighLight(true);
    }

    private void OnMouseExit()
    {
        EnableHighLight(false);
    }
}
