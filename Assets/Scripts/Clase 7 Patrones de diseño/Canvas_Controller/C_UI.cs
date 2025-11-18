using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class C_UI : MonoBehaviour, IObserver {
    private ManagerGame game;
    public TextMeshProUGUI TextoPuntos;

    private void Awake() {
        game = FindObjectOfType<ManagerGame>();
        game.AgregarObservadores(this);
    }


    public void Points(int Points) {
        TextoPuntos.text = Points.ToString();
    }

}
