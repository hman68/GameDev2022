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
    public float maxSpeed;
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
        if(!GetComponent<MovementAction>().isDashing && hyp != 0){
            playerRB.AddForce(new Vector3((horizontalInput/hyp)*speed,0f, (verticalInput/hyp) * speed));
        }
        if(!GetComponent<MovementAction>().isDashing){
            Vector3 vel = playerRB.velocity;
            if(vel.magnitude > maxSpeed){
                vel = new Vector3((vel.x/vel.magnitude) * maxSpeed, 0f, (vel.z/vel.magnitude) * maxSpeed);
                playerRB.velocity = vel;
            }
        }
        if(horizontalInput == 0){
            playerRB.AddForce(-playerRB.velocity.x * speed,0f,0f);
            Debug.Log("works");
        }
        if(Mathf.Abs(playerRB.velocity.x) < 0.001f){
            playerRB.velocity = new Vector3(0f, playerRB.velocity.y, playerRB.velocity.z);
        }
        if(playerRB.velocity.z< 0.001f){
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, 0f);
        }
    }


}
