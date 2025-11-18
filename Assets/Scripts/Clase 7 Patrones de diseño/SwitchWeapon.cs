using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private IAttackStrategy attackStrategy;

    // Cambiar la estrategia de ataque en tiempo de ejecución
    public void SetAttackStrategy(IAttackStrategy newStrategy) {
        attackStrategy = newStrategy;
    }

    // Ejecutar el ataque según la estrategia definida
    public void Attack() {
        if(attackStrategy != null) {
            attackStrategy.ExecuteAttack();
        }
    }

    // Ejemplo de cómo cambiar la estrategia durante el juego
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            SetAttackStrategy(new QuickAttack()); // Selecciona el ataque rápido
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            SetAttackStrategy(new SlowAttack()); // Selecciona el ataque lento
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            SetAttackStrategy(new ExplosiveAttack()); // Selecciona el ataque explosivo
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack(); // Ejecuta el ataque según la estrategia seleccionada
        }

    }
}
/*
 con este patron, puedo cambiar entre diferentes script, mientras que, tengan la misma interfaz como herencia
 lo puedo asignar esa variable por eventos Ontrigger, oncollider y etc. pero debo llenar esa variable con un metodo public

    public void SetAttackStrategy(IAttackStrategy newStrategy) {  <<<<<<<<<<<<<
        attackStrategy = newStrategy;
    }

 */