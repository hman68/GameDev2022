using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        speed = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(EventManager.currentGameState == GameState.Play)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
    }
}
