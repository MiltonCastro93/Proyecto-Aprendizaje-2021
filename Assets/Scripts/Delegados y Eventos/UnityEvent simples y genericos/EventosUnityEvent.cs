using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;

public class EventosUnityEvent : MonoBehaviour {
//la diferencia entre UnityEvent y Event, se radica entre como se agrega funcionalidad.
//en UnityEvent desde el inspector, mientras que, en el event por codigo
    // Este evento se ve en el Inspector
    public UnityEvent DoorOpen; //Siempre se los asignan
    public UnityEvent<Rigidbody> status; //Nunca se veran actualizarse, se resulven instantaneamente
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            Abrir();            
        }
    }

    public void Abrir() {
        Debug.Log("Puerta abierta (UnityEvent)");
        DoorOpen.AddListener(Saludos); //-> van siempre antes del invoke

        DoorOpen.Invoke(); // Dispara todo lo que esté asignado en el Inspector
        estado(gameObject.GetComponentInChildren<Rigidbody>());
    }

    public void estado(Rigidbody rb) {
        rb.isKinematic = !rb.isKinematic;
        status.Invoke(rb);
    }

    public void Saludos() {
        Debug.Log("HOLAAAAAAAA");
        DoorOpen.RemoveListener(Saludos);
    }

}

/*usar los UnityEvent, es para agrupar varios comportamientos, y llamar esa accion con el .invoke()
Ventajas:
    Visual y fácil de usar.
    Serializable -> se guarda en la escena/prefab.
    Útil en prototipos y cuando querés que un diseñador/level designer conecte cosas sin escribir código.

Desventajas:
    Un poco más lento (usa reflexión interna).
    Menos controlado en tiempo de compilación (si borrás una función desde el Inspector, el enlace queda roto y no da error hasta runtime).
 */