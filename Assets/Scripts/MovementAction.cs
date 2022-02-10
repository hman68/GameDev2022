using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : MonoBehaviour
{
    private Rigidbody rb;
    public int dashLen;
    public float dashSpeed;
    private Vector3 normVelocity;
    private bool isDashing = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            Debug.Log("DashAttempt");
            StartCoroutine(Dash());
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space");
        }
        //Stops the object after it moves the maximum dash length
        /*if(pos != null && Vector3.Distance(rb.position,pos.v3)>maxLen){
            isDashing = false;
            if(Input.GetKey(KeyCode.D)){
                rb.velocity = new Vector3(10f,0f,0f);
               normVelocity = null;
            }else{
                while(rb.velocity.magnitude > 0.01f){
                    rb.velocity = rb.velocity*.02f;
                }
                rb.velocity = Vector3.zero;
               normVelocity = null;
            }
            
        }*/
    }
    /*
    Dashes the character in a certain direction
    */
    IEnumerator Dash()
    {
        Debug.Log("Dashing");
        isDashing = true;
       normVelocity = rb.velocity;
        rb.velocity = new Vector3(dashSpeed * (rb.velocity.x/rb.velocity.magnitude), rb.velocity.y,  dashSpeed * (rb.velocity.z/rb.velocity.magnitude));
        yield return new  WaitForSecondsRealtime(dashLen);
        Debug.Log("endDash");
        rb.velocity = normVelocity;
        yield return new WaitForSecondsRealtime(10);
        isDashing = false;
    }
}
