using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody proj;
    private Rigidbody player;
    private bool rtf; // ready to fire
    public float rpm;
    public float travelTime;
    void Start()
    {
        rtf = true;
        speed = 25.0f;
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        proj = GameObject.FindWithTag("Projectile").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && rtf){
            StartCoroutine(Shoot());
            Debug.Log("Shoot");
        }
    }

    IEnumerator Shoot(){
        Rigidbody clone;
        rtf = false;
        clone = (Rigidbody)Instantiate(proj, player.position + (player.rotation * new Vector3(0,0,0.5f)), player.rotation);
        clone.AddForce(clone.rotation * Vector3.forward * speed, ForceMode.VelocityChange);
        yield return new WaitForSecondsRealtime(1f);
        rtf = true;
        yield return new WaitForSecondsRealtime(travelTime);
        Destroy(clone.gameObject);
        
    }
}
