using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent OnFirstTouch;
    public UnityEvent OnStartTouch;
    public UnityEvent OnTouch;


    private void OnTriggerEnter(Collider other) {
        var obj = other.gameObject;
        if(obj.CompareTag("Player")) {
            OnStartTouch.Invoke();
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0.45f, 0.10f, 0.5f);
        Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
    }
}
