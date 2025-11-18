using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usedStack : MonoBehaviour {
    Stack<Vector3> _actionMove = new Stack<Vector3>();
    [SerializeField] Vector3 _firstPosition = Vector3.zero;
    [SerializeField] int _maxIndex = 4, _currentIndex = 0;

    private void Start() {
        _actionMove.Push(transform.position);
        _firstPosition = _actionMove.Peek();//Muestro el último sin eliminarlo.
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A) && _actionMove.Count < _maxIndex) {
            Debug.Log("Posicion Guardada");
            _actionMove.Push(transform.position);//Agrego mi position
        }

        if (Input.GetKeyDown(KeyCode.D) && _actionMove.Count > 0) {
            Debug.Log("Posicion Revertida");
            transform.position = _actionMove.Pop();//Muestro el ultimo y luego lo elimino
        }

        if(_firstPosition == transform.position && _actionMove.Count == 0) {
            _actionMove.Push(_firstPosition);
        }

        _currentIndex = _actionMove.Count;
    }
}

/*
Usando Stack y sus usos mas comunes son:
        Deshacer acciones (undo). Tipicos juegos donde queres deshacer una accion que no te conviene o como el "Supermarket Together"
        Guardar historial de estados.

Funciona con el principio LIFO (Último en entrar, primero en salir). < A, B, C, D .... Sale primero "D"
*/