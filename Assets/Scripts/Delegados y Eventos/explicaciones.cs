using System;
using UnityEngine;
using UnityEngine.Events;

public class explicaciones : MonoBehaviour
{
    //Delegados = se pueden invocar desde donde sea(si son públicos).
    public delegate void MyDelegados();
    MyDelegados myDelegados;

    //Events = solo la clase dueña puede invocarlos.
    public event Action EVENTO;

    //UnityEvent = solo la clase dueña puede invocarlos
    public UnityEvent unityEvent;

    //Estos tres mientras que sean publicos, pueden suscribirse funciones agenas de la clase.

    private void Start() {
        myDelegados += Sumar;
        EVENTO += Sumar;
        unityEvent.AddListener(Sumar);

        myDelegados?.Invoke();
        EVENTO?.Invoke();
        unityEvent?.Invoke();

        myDelegados -= Sumar;
        EVENTO -= Sumar;
        unityEvent.RemoveListener(Sumar);
    }


    private void Sumar()
    {
        Debug.Log("Sumando...");
    }

}
