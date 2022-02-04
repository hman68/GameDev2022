using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Null{
    public Vector3 v3 { get; set; }
}

public class MovementAction : MonoBehaviour
{
    private Rigidbody rb;
    public int maxLen;
    public float dashSpeed;
    private Vector3Null def = new Vector3Null();
    private Vector3Null pos;
    private bool isDashing;
    // Start is called before the first frame update
    void Start()
    {
        pos = def;
        rb = GetComponent<Rigidbody>();
        pos.v3 = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            Dash();
        }
        //Stops the object after it moves the maximum dash length
        if(pos != null && Vector3.Distance(rb.position,pos.v3)>maxLen){
            isDashing = false;
            if(Input.GetKey(KeyCode.D)){
                rb.velocity = new Vector3(10f,0f,0f);
                pos = null;
            }else{
                while(rb.velocity.magnitude > 0.01f){
                    rb.velocity = rb.velocity*.02f;
                }
                rb.velocity = Vector3.zero;
                pos = null;
            }
            
        }
    }
    /*
    Dashes the character in a certain direction
    */
    IEneumerator Dash()
    {
        isDashing = true;
        pos = def;
        pos.v3 = rb.position;
        rb.velocity = new Vector3(rb.velocity.x * 10f, rb.velocity.y, rb.velocity.z * 10f);
        return new yield WaitForSeconds(1);
        isDashing = false;
    }
}
