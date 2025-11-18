using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCorrutinas : MonoBehaviour
{
    private Material material;
    private enum Type { Funcion, Corrutina}
    [SerializeField] private Type type;
    [SerializeField] float value = 1f;
    Coroutine rotationCoroutine;

    public string task;

    private void Start() {
        material = GetComponent<MeshRenderer>().material;

        if(type == Type.Funcion) {

        } else {
            CoroutineManager.RUN(gameObject.name + "Color", colorTranslate());
            //StartCoroutine("colorTranslate"); //Creo una instancia de esta corrutina
        }

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {//al tener referencia de esta la podre detener
            CoroutineManager.STOP(gameObject.name + task);
            if (rotationCoroutine != null) {
                //StopCoroutine(rotationCoroutine);
                rotationCoroutine = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) { //Hago que entre una sola vez
            CoroutineManager.RUN(gameObject.name + task, turned());
            if (rotationCoroutine == null) {
                //rotationCoroutine = StartCoroutine(turned());
            }
        }

    }

    IEnumerator colorTranslate() {//al crear una corrutina, tendras que crear un loop interno para que haga algo.
        bool endTask = false;
        while (value > 0) {
            value -= Time.deltaTime;
            value = Mathf.Clamp(value, 0f, 1f);
            material.color = new Color(value, 0, 0, 1);
            yield return null;//provoca otro giro
        }

        //todo lo despues lo hace una vez como una funcion normal y se muere
        endTask = true;
        if (endTask) {
            //Es recomendado hacer esto, ya que obtener referencia de la corrutina
            //rotationCoroutine = StartCoroutine(turned());
        }
    }

    IEnumerator turned() {
        while (true) {
            transform.rotation *= Quaternion.Euler(0, 2f * Time.deltaTime, 0);
            yield return null;
        }

    }

}
