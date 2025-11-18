using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] PoolBullet _poolBullet;

    private void Awake() {
        _poolBullet = GetComponent<PoolBullet>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _poolBullet.GetBullet(transform.position, transform.rotation);
        }

    }

}
