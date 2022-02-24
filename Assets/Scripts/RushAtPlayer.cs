using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAtPlayer : MonoBehaviour
{
    //Ok so when I read the description, I assumed that the goblins would be moving at normal speeds until they see a player.
    // Start is called before the first frame update
    GameObject player;
    Transform playerTransform;
    GameObject gameManager;
    GameManager gameManagerScript;
    [SerializeField]
    float distToDash;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        //player = gameManagerScript.player;
        playerTransform = gameManagerScript.playerTransform;
        distToDash = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, this.transform.position) < distToDash) 
        {
            StartCoroutine(dash());
        }
    }
    IEnumerator dash() 
    {
        //This line is just to get rid of the error.
        yield return new WaitForSeconds(1);
        /*
        Debug.Log("Dashing");
        isDashing = true;
        normVelocity = rb.velocity;
        rb.velocity = new Vector3(dashSpeed * (rb.velocity.x / rb.velocity.magnitude), rb.velocity.y, dashSpeed * (rb.velocity.z / rb.velocity.magnitude));
        yield return new WaitForSecondsRealtime(dashLen);
        Debug.Log("endDash");
        rb.velocity = normVelocity;
        yield return new WaitForSecondsRealtime(10);
        isDashing = false;
        */
    }
}
