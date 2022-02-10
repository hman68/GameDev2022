using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    //Ok so the original plan was to have spawners be an event that was subscribed to, and this is kind of an extension of that. This script simply activates or deactivates spawners.
    //In theory, this is attached to an invisible object that follows the player and activates spawners that are either in a room or in a large radius beyond the players view
    //This should allow for spawners to be active both in dungeons and when not in dungeons
    public float radius;
    public GameObject[] Spawners;
    private float[] spawnerDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable() 
    {
        //This calls an the OnSceneLoaded event anytime a scene changes. So that it can check for spawners when the scene changes.
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Ok so my first thought was to check distance for each spawner constantly and see which will need to be deactivated or activated
        //But I think that will be too resource intensive, so I want to find a better solution.
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = 0; i < Spawners.Length; ++i) 
        {
            float distanceFromPlayer = Vector3.Distance(this.transform.position, Spawners[i].transform.position);
            if (distanceFromPlayer > radius)
            {
                Spawners[i] = null;
                --i;
            }
            else spawnerDistance[i] = Vector3.Distance(this.transform.position, Spawners[i].transform.position);
        }
    }
}
