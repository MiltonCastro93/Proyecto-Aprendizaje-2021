using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody _rb;    
    public ObjectPool<Projectile> pool;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        Invoke("Deactivate", 3f);
    }

    private void OnDisable() {
        CancelInvoke(); // Previene múltiples invocaciones
    }

    private void OnCollisionEnter(Collision collision) {
        Deactivate();
    }

    private void Deactivate() {
        pool.Release(this);
    }

    public void Launch(Vector3 direction) {
        _rb.velocity = direction * speed;
    }

}
