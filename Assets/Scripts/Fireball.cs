using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    //So the fireball will have an aoe. It will explore either upon hitting terrain, an enemy, or when it runs out of duration.
    // Start is called before the first frame update
    float timeToExplode;
    Vector3 center;
    float radius;
    float damage;
    bool enemyFired;
    void Start()
    {
        timeToExplode = 10.0f;
        //The fireball will explode at a set time
        explode(timeToExplode  * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Ok so this method takes in a float, time. Time determines how long it will take for the fireball to expire.
    //When it does expire, the fireball will get all of the colliders in the radius of itself (the center), and damage them.
    
    IEnumerator explode(float time) 
    {
        yield return new WaitForSeconds(time);
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders) 
        {
            //Not entirely how we will handle things taking damage
            //Also enemyFired is supposed to be used here to determine whether the fireball does damage to the player or to enemies. 
            //But again enemies dont yet exist.
            //hitCollider.damage(damage);
        }
    }
}
