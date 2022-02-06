using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public GameObject playerAim;
    private Rigidbody projectileRB;
    private Vector3 mouseRot;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Gets mouse rotation and projectile rigid body
        mouseRot = Projectile.GetMouseRot();
        projectileRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sends the projectile in the direction of the mouse
        projectileRB.AddForce(mouseRot * speed, ForceMode.Impulse);
    }
   
}
