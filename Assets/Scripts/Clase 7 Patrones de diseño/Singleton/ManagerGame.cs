using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    private static ManagerGame managerGame;
    public static ManagerGame GameManager => managerGame;

    List<IObserver> observers = new List<IObserver>();
    private int Points = 0;

    private void Awake() {
        if (managerGame == null) {
            managerGame = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

    }


    public void AgregarObservadores(IObserver observer) {//Aca verifico y agrego uno a la lista
        if (!observers.Contains(observer)) {
            observers.Add(observer);
        }
    }

    public void EliminarObservador(IObserver Delete) {
        if (observers.Contains(Delete)) {
            observers.Remove(Delete);
        }
    }

    public void ActualizarPoint(int ActualizarPuntos) {
        Points += ActualizarPuntos; //Esta funcion sera para que todos puedan enviar el puntaje
        Notificar();
    }

    private void Notificar() {
        foreach (IObserver observer in observers) {
            observer.Points(Points);
        }
    }

}
