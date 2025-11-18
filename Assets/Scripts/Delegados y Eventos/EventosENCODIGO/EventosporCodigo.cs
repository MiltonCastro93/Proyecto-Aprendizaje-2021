using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosporCodigo : MonoBehaviour
{
//la diferencia entre UnityEvent y Event, se radica entre como se agrega funcionalidad.
//en UnityEvent desde el inspector, mientras que, en el event por codigo
    public event Action alAbrirse;

    public void Abrir() {
        Debug.Log("Puerta abierta (C# event)");
        alAbrirse?.Invoke(); // Dispara a los suscriptores
        Debug.Log(alAbrirse.GetInvocationList().Length);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Abrir();
        }
    }

}
/*
Ventajas:
    Más rápido y seguro en tiempo de compilación.
    Código más claro para proyectos grandes.
    Control total (podés manejar suscripción/desuscripción de forma estricta).

Desventajas:
    No aparece en el Inspector.
    Solo programadores pueden conectarlo (no artistas/diseñadores).
*/

/* 
UnityEvent
    Se diseña para ser editable desde el Inspector de Unity.
    Podés arrastrar un objeto y elegir qué método de ese objeto se dispara.
    También se puede suscribir por código (myUnityEvent.AddListener(MiMetodo)), pero lo fuerte es el Inspector.

event (C#)
    Se suscribe solo desde código usando += y se elimina con -=.
    No aparece en el Inspector.
*/