using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour {
    private int _danio = 20;

    public void Attack(GameObject target) {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null) {
            damageable.TakeDamage(_danio);
        
        }
    }

    private void OnTriggerEnter(Collider other) {
        IDamageable damageable = other.GetComponent<IDamageable>(); //Todo aquel que tenga la interface como "herencia" le sacare vida
        if (damageable != null) {
            damageable.TakeDamage(_danio);

        }
    }



}
