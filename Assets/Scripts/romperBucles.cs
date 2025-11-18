using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romperBucles : MonoBehaviour
{
    [SerializeField] private int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public bool _break = true;

    void Start() {
        for (int i = 0; i < num.Length; i++) {
            if (num[i] == 5) {
                break; //Con este Rompera cualquier Bucle (Al momento de detectar "5", sale al instante del bucle)
            }
            Debug.Log("Esto es Break: " + num[i]); //1; 2; 3; 4; FIN
        }
        for (int i = 0; i < num.Length; i++) {
            if (num[i] == 5) {
                continue; //Con este Salteara un paso (Al momento de detectar "5", sale y vuelve al mismo bucle, salteando toda interaccion "pasada")
            }
            Debug.Log("Esto es un Continue: " + num[i]); // 1; 2; 3; 4; 6; 7; 8; 9; FIN!
        }

    }


}
