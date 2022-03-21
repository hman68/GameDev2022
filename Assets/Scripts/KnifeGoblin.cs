using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeGoblin : MonoBehaviour
{
    /// <summary>
    /// This script is supposed to test how enemies behavior as well as how well dashing will work for them and projectiles.
    /// In the future, this will be deleted
    /// </summary>
    public float health;
    float speed;
    Rigidbody monsterRb;
    float countdown;
    public GameObject projectile;
    public GameObject player;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        health = 10.0f;
        speed = 1.0f;
        monsterRb = GetComponent<Rigidbody>();
        countdown = 10.0f;
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        /*
        if (EventManager.currentGameState == GameState.Play)
        {
            countdown -= 1 * Time.deltaTime;
            if (countdown < 0)
            {
                Instantiate(projectile);
                countdown = 1.0f;
            }
        }
        */
    }
    public void takeDamage(float damage) 
    {
        health -= damage;
    }
}
