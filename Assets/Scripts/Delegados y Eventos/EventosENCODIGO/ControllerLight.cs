using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLight : MonoBehaviour
{
    public EventosporCodigo puerta;
    private Light luz;
    public float currentTime = 0f;
    public float TimeMaxOn = 5f;

    void Awake() {
        luz = GetComponent<Light>();
    }

    void OnEnable() {
        // Me suscribo al evento
        puerta.alAbrirse += EncenderLuz;
        puerta.alAbrirse += Red;
    }

    void OnDisable() {
        // Me desuscribo (buena práctica)
        puerta.alAbrirse -= EncenderLuz;
    }

    void EncenderLuz() {
        luz.enabled = true;
    }

    void Red() {
        luz.color = Color.red;
    }

    void Update() {
        if (luz.enabled) {
            currentTime += Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime, 0f, TimeMaxOn);
            if(currentTime >= TimeMaxOn) {
                currentTime = 0f;
                luz.enabled = false;
            }
        }
    
    }

}
