using UnityEngine;
using System.Threading.Tasks;
using System.Threading; //Es una forma mas moderna

public class AsyncAwait : MonoBehaviour {
    async void Start() {
        Debug.Log("Empezando Tarea via Async...");

        await Task.Run(() =>//Este es otro Hilo, nunca debes poner un componente del Unity aca
        {
            //Trabajo en segundo plano
            Debug.Log("Calculando al Pesado (Async)");
            Thread.Sleep(3000);//Simula una carga pesada
            Debug.Log("Listo. (Async)");
        });

        //Afuera modificar todo lo que quieras
        Debug.Log("Tarea Finalizada (Async)");
    }



}

//Sus usos Optimos Threads o Async/Await
/*
 IA Avanzada (Ej. Estrategia, Simulacion)
 Calculos de Pathfinding (A*)
 Lectura de archivos Pesados
 Comunicacion de red

[Thread] es como manejar un auto manual.
[async/await] es como un auto automático: más seguro, menos control, pero más cómodo para el 90% de los casos.
 */
//Corrutinas------------------------------
/*
 Fade de UI
 Movimiento de Personajes
 */