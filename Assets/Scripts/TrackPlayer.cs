using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    //This script will allow objects, and hopefully projectiles, to rotate towards the player.
    // Start is called before the first frame update
    GameObject GameManager;
    GameManager gmScript;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gmScript = GameManager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(gmScript.playerTransform);
    }
}
