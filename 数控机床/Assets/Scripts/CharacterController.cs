using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rigid;
    public KMInput input;
    private Vector3 moveDampSpeed;
    public float smoothTime = 0.3f;
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetSpeed = Vector3.zero;
        if(Signal.keyboardEnable)
        {
            targetSpeed = Vector3.Normalize(this.transform.forward * input.Kup + this.transform.right * input.Kright) * speed;
        }
        rigid.velocity = targetSpeed;
    }
}
