using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoLuz : MonoBehaviour
{
    private Light _light;

    // Start is called before the first frame update
    void Start() {
        _light = GetComponent<Light>();
    }

    public void Alternar() {
        _light.enabled = !_light.enabled;
    }

}
