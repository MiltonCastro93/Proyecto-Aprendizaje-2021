using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAttack : IAttackStrategy {
    public void ExecuteAttack() {
        Debug.Log("¡Ataque lento!");
    }
}
