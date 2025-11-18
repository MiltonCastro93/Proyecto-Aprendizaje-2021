using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) { // estoy obligado a traer la funcion "Abstracta" del Interface IDamageable
        health -= damage;
        Debug.Log("Jugador recibio daño. Vida restante: " + health);
    }

}
