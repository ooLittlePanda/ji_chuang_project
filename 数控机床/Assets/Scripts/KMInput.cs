using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMInput : MonoBehaviour
{
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    public float Mup;
    public float Mright;
    public float Kup;
    public float Kright;

    public float mouseSensitivityX = 1.0f;
    public float mouseSensitivityY = 1.0f;
    public float minmouseY = -80;
    public float maxmouseY = 80;

    private void Update()
    {
        if (Signal.inputEnable)
        {
            Mup = Input.GetAxis("Mouse Y") * mouseSensitivityY;
            Mright = Input.GetAxis("Mouse X") * mouseSensitivityX;
                
            Kup = (Input.GetKey(keyUp) ? 1.0f : 0.0f) - (Input.GetKey(keyDown) ? 1.0f : 0.0f);
            Kright = (Input.GetKey(keyRight) ? 1.0f : 0.0f) - (Input.GetKey(keyLeft) ? 1.0f : 0.0f);
            if (Kup != 0 || Kright != 0) Signal.Move = true;
            else Signal.Move = false;
        }
    }
}
