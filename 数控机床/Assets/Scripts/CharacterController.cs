using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 2.0f;
    private float sqrtSpeed;
    private Rigidbody rigid;
    public KMInput input;
    private Vector3 moveDampSpeed;
    public float smoothTime = 0.3f;
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        sqrtSpeed = Mathf.Sqrt(speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetSpeed = Vector3.zero;
        if(input.keyboardEnable)
        {
            if(input.Kup!=0&&input.Kright!=0)
            {
                targetSpeed = (this.transform.forward * input.Kup + this.transform.right * input.Kright) * sqrtSpeed;
            }
            else
            {
                targetSpeed = (this.transform.forward * input.Kup + this.transform.right * input.Kright) * speed;
            }
        }
        //rigid.velocity = Vector3.SmoothDamp(rigid.velocity, targetSpeed, ref moveDampSpeed, smoothTime);
        rigid.velocity = targetSpeed;
    }
}
