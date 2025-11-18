using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class usedQueue : MonoBehaviour {
    Queue<GameObject> _posFree = new Queue<GameObject>();
    [SerializeField] private GameObject[] _prefabsEnemies;
    [SerializeField] bool _presentEnemies = false;


    // Update is called once per frame
    void Update() {
        if(_posFree.Count < 4 && !_presentEnemies) {
            GameObject enemigo = Instantiate(_prefabsEnemies[Random.Range(0, _prefabsEnemies.Length)]);
            _posFree.Enqueue(enemigo);
            if(_posFree.Count >= 4) {
                _presentEnemies = true;
            }
            Debug.Log("TIPO DE ENEMIGO: " + enemigo.name);
        }

        if (Input.GetKeyDown(KeyCode.D) && _posFree.Count > 0) {
            _posFree.Dequeue();
            Debug.Log("Enemigo Eliminado");
        }

        if (_posFree.Count == 0 && _presentEnemies) {
            Debug.Log("Ronda Ganada");
        }

    }

}
/*
Usando Queue y sus usos mas comunes son:
        Procesar eventos en orden.
        Gestionar colas de enemigos o tareas. Tipicos juegos en donde debes matar a lacayos para finalmente matar al jefe y ganar la ronda

Funciona con el principio FIFO (Primero en entrar, primero en salir).< A, B, C, D .... Sale primero "A"
*/