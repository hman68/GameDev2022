using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 mousePos;
    public Camera main;
    private static Vector3 mouseRot;
    public GameObject projectile;
    private Rigidbody projectileRB;

    void Start()
    {
        //Gets projectile rigid body
        projectileRB = FindObjectOfType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets current mouse position for finding the position on the floor
        mousePos = Input.mousePosition;
        //This sends a ray out from the camera, where the mouse is, and gets where it lands, which it lands on the ground
        Ray mouseRay = main.ScreenPointToRay(mousePos);
        RaycastHit raycastHit;
        if (Physics.Raycast(mouseRay, out raycastHit))
        {
            //Saves the mouse position on the floor into a variable
            mouseRot = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
            //Makes the aimer look at the mouse
            transform.LookAt(mouseRot);
        }
        //Makes a projectile when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            MakeProjectile(mouseRot);
        }
    }
    //Getter for mouse rotation for the projectile
    public static Vector3 GetMouseRot()
    {
        return mouseRot;
    }
    //Makes projectile
    public void MakeProjectile(Vector3 mouseRot)
    {
        Instantiate(projectile, player.transform.position, transform.rotation);
    }

        
}
