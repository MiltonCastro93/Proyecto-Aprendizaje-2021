using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personaje : MonoBehaviour {
    protected int _life = 100;
    protected float _speed = 2f;


    protected abstract void Walking();
    protected virtual void OnDie() {
        Debug.Log("Me mori");
    }

}
