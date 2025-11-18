using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int PuntosGanados;
    private ManagerGame game;

    // Start is called before the first frame update
    void Start() {
        game = FindObjectOfType<ManagerGame>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            game.ActualizarPoint(PuntosGanados);
        }


    }


}
