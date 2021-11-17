using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraHandle;
    public KMInput input;
    public float shakeMaxDist = 5.0f;
    public float shakeSpeed = 3.0f;

    private float RotationX = 0f;
    private float RotationY = 0f;
    private Vector3 PlayerToCamera;
    private Vector3 cameraInitPosition;
    private bool shakeUp = true;
    private float shakeDist;

    // Update is called once per frame
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    private void Start()
    {
        PlayerToCamera = cameraHandle.transform.position - this.transform.position;
        cameraInitPosition = this.transform.position;
        shakeDist = 0;
    }
    void LateUpdate()
    {
        if (input.mouseEnable)
        {
            RotationX += input.Mright;
            RotationY -= input.Mup;
            RotationY = Mathf.Clamp(RotationY, input.minmouseY, input.maxmouseY);
        }

        this.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
        cameraHandle.transform.localEulerAngles = new Vector3(0, RotationX, 0);

        Debug.Log(shakeUp);
        Debug.Log("shakeDist:" + shakeDist);
        Debug.Log("shakeMaxDist" + shakeMaxDist);
        if(input.Move)
        {
            if (shakeUp)
            {
                shakeDist += Time.deltaTime * shakeSpeed;
                if (shakeDist >= shakeMaxDist) shakeDist = shakeMaxDist;
            }
            else
            {
                shakeDist -= 2*Time.deltaTime * shakeSpeed;
                if (shakeDist <= 0) shakeDist = 0;
            }

            if (shakeDist >= shakeMaxDist) shakeUp = false;
            else if (shakeDist <= 0) shakeUp = true;
        }

        this.transform.position = cameraHandle.transform.position - PlayerToCamera + new Vector3(0, shakeDist, 0);
    }
}
