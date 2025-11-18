using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Personaje {



    // Start is called before the first frame update
    void Start() {
        Walking();
    }

    // Update is called once per frame
    void Update() {
        if (_life > 0) {
            _life--;
        }
    }

    protected override void Walking() {
        Debug.Log("Camino");
    }


}
