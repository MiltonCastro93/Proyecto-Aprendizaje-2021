using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    private Dictionary<string, Coroutine> _diccionario = new Dictionary<string, Coroutine>();

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static Coroutine RUN(string key, IEnumerator routine) {
        // es como el ContainsKey, pero mas limpio y obtengo la key y su valor
        if (instance._diccionario.TryGetValue(key, out Coroutine existing)) {
            Debug.Log("Ya Existe, pasare a detener y eliminar");
            instance.StopCoroutine(existing);//con la Out hago referencia a usar variable local
            instance._diccionario.Remove(key);
        }
        Coroutine newCoroutine = instance.StartCoroutine(routine);
        instance._diccionario[key] = newCoroutine;
        Debug.Log("Nueva Corrutina Añadida");
        return newCoroutine;
    }

    public static void STOP(string key) {
        if (instance._diccionario.TryGetValue(key, out Coroutine current)) {
            instance.StopCoroutine(current);
            instance._diccionario.Remove(key);
        }
    }

    public static void StopALL() {
        foreach(var allforOne in instance._diccionario) {
            instance.StopCoroutine(allforOne.Value);
        }
        instance._diccionario.Clear();
    }


}
