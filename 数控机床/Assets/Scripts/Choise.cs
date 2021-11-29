using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]

public class Choise : MonoBehaviour
{

    public GameObject image;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Material originMat;

    [SerializeField]
    private Material highLightMat;

    [SerializeField]
    private float distance = 4.0f;
    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        EnableHighLight(false);
    }

    private void Update()
    {
      
    }
    protected void EnableHighLight(bool on_off)
    {
        if (meshRenderer != null && originMat != null && highLightMat != null)
        {
            if (Vector3.Distance(this.transform.position, Signal.player.transform.position) < distance)
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
        if (Input.GetKeyDown("e"))
        {
            if (image.activeInHierarchy)
            {
                image.SetActive(false);
            }
            else
            {
                image.SetActive(true);
            }
        }

    }

    private void OnMouseExit()
    {
       
        EnableHighLight(false);
       
    }


}
