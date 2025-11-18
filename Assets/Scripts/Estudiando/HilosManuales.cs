using UnityEngine;
using System.Threading;

public class HilosManuales : MonoBehaviour {

    Vector3 nuevaPosicion;
    bool listo = false;

    void Start() {
        Thread hilo = new Thread(() => {
            // Simular cálculo
            Thread.Sleep(1000);
            nuevaPosicion = new Vector3(2, 3, 4);
            listo = true;
        });
        hilo.Start();
        //aca tambien puedo modificar la posicion

    }

    void Update() {
        if (listo) {
            transform.position = nuevaPosicion;
            listo = false; // resetear
        }
    }


}
