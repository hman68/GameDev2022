using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float horizontalInput;
    private float verticalInput;
    private float prevHoriz;
    private float prevVert;
    private float hyp;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        hyp = MathF.Sqrt((horizontalInput * horizontalInput)+(verticalInput * verticalInput));
        playerRB.AddForce(new Vector3((horizontalInput/hyp)*speed,0f, (verticalInput/hyp) * speed));
    }

    void ShitYourPants()
    {
        
    }
}
