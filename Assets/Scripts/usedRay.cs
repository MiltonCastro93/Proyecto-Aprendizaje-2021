using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usedRay : MonoBehaviour {
    public GameObject _player;

    private void FixedUpdate() {
        if(_player != null) {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, _player.transform.position, out hit, Mathf.Infinity)) {
                Debug.Log(hit.collider.name);
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.green);
            }
        }
    }



}
