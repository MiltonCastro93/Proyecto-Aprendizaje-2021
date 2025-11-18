using UnityEngine;
using System.Threading.Tasks;

public class AplicandoAsyncGO : MonoBehaviour
{
    public GameObject cuboA;
    public GameObject cuboB;
    private Animator myAnimator;

    // Start is called before the first frame update
    async void Start() {
        //Guardo por referencias ambas tareas, ya que, las task siempre crean nuevas intancias
        Task tareaA = TareaParaCuboA();
        Task tareaB = TareaParaCuboB();

        await Task.WhenAll(tareaA, tareaB); // < Ejecuto en paralelo
        
        if (tareaA.IsCompleted && tareaB.IsCompleted) {//pregunto si han finalizado todas
            Debug.Log("Ambas tareas terminaron");
        }
        //---------------------------------------------------------------
        Task t1 = OtherTask();
        Task t2 = changeTask();

        Task taskFinish = await Task.WhenAny(t1, t2);
        if (taskFinish == t1) {
            Debug.Log("Completa la 1° tarea");
        } else {
            Debug.Log("Completa la 2° tarea");
        }

    }

    async Task TareaParaCuboA() {
        //Tarea Pesada
        int x = await Task.Run(() => {
            System.Threading.Thread.Sleep(1000);
            return 3;
        });

        //Modificacion Segura, fuera del Sub Hilo        
        cuboA.transform.localPosition = new Vector3(x, 0, 0);
    }

    async Task TareaParaCuboB() {
        //Tarea Pesada
        int y = await Task.Run(() => {
            System.Threading.Thread.Sleep(1500);
            return 5;
        });
        //Modificacion Segura
        cuboB.transform.localPosition = new Vector3(0,y, 0);
    }

    async Task OtherTask() {
        Debug.Log("Other Task Start");

        //No crea un hilo, solamente duerme el codigo 1 segundo
        await Task.Delay(1000);
        Debug.Log("Pasó 1 segundo");

        await Task.Run(() => { //Creo un hilo
            // Tarea pesada
            System.Threading.Thread.Sleep(1000);
        });
        Debug.Log("Terminó tarea pesada");

        // No crea un hilo, solo espera un frame
        await Task.Yield();
        Debug.Log("Siguiente frame");
    }

    async Task changeTask() {//Regla de Oro
        Debug.Log("Change Task Start");
        await Task.Delay(2000);//Si necesitás tocar objetos Unity: Coroutine o async/await (en el hilo principal).
        if (myAnimator != null) {
            myAnimator.SetTrigger("Disparar");
            Debug.Log("Fuego");
        }

        Debug.Log("Paso 2 Segundos");

        await Task.Run(() => { // Si necesitás hacer muchos cálculos o IA pesada: Task.Run o Thread.
            //"Tarea Pesada" por ser Task.Run es otro Hilo nada de (Transform, cosas nativas del unity)
            System.Threading.Thread.Sleep(1000);
        });
        Debug.Log("Terminó tarea pesada");

    }

}
/*
 1. Creación de Tareas
    Task.Run(() => { ... })     Ejecuta una acción en un hilo del pool (para trabajo pesado).
    Task.Delay(ms)              Espera asincrónicamente sin bloquear el hilo actual.
    Task.FromResult(valor)      Crea una tarea ya completada con un valor.
    Task.CompletedTask          Tarea ya completada sin valor (void).
    Task.Yield()                Espera hasta el siguiente "tick"/frame, cediendo el control.

 2. Composición de Tareas
    await Task.WhenAll(...)     Espera que todas las tareas terminen (en paralelo).
    await Task.WhenAny(...)     Espera a que termine la primera tarea de un grupo.
    Task.WaitAll(...)           Igual que WhenAll pero bloqueante (¡no recomendable en Unity!).
    Task.WaitAny(...)           Igual que WhenAny pero bloqueante.
    Task.ContinueWith(...)      Ejecuta una tarea al finalizar otra (encadenamiento).

 3. Verificación de estado
    task.IsCompleted            Indica si terminó la tarea.
    task.IsCanceled             Indica si fue cancelada.
    task.IsFaulted              Indica si falló con excepción.
    task.Result                 Obtiene el resultado (solo si ya terminó).
    task.Exception              Contiene la excepción si falló.

 4. Cancelación (opcional)
    CancellationToken                       Permite cancelar una tarea manualmente.
    token.ThrowIfCancellationRequested()    Lanza excepción si se solicita cancelación.
    token.IsCancellationRequested           Chequea si se pidió cancelar.
 */