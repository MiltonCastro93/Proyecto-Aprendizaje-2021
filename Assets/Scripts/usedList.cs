using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usedList : MonoBehaviour {
    [SerializeField] private Transform _player; //Ref del player
    [SerializeField] List<Transform> _enemies; // Lista de Enemigos

    void Update() {
        Transform nearestEnemy = FindNearestEnemy(_player.position);
        if(nearestEnemy != null) {
            Debug.Log("El enemigo mas cercano esta en: " + nearestEnemy.name);
        }
    }

    Transform FindNearestEnemy(Vector3 playerPosition) {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach(Transform enemy in _enemies) {
            float distance = Vector3.Distance(playerPosition, enemy.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestEnemy = enemy;            
            }
        }
        return closestEnemy;
    }

}

/*
Las Listas son buenas para usarse con elementos numericos, y el abecedario, no te conviene para los vectores, gameobject y etc, ya que, no posee estructura para leer estos componentes.
para ello se debe usar "Stack" o "Queue"
 */