using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject projectile;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        while (true) 
        {
            countdown -= 1 * Time.deltaTime;
            if (countdown < 0) 
            {
                Instantiate(projectile);
                countdown = 5.0f;
            }
        }
    }
}
