using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class usedDictionary : MonoBehaviour {
    Dictionary<string, int> playerScores = new Dictionary<string, int>();

    private void Start() {
        playerScores.Add("Player 1", 10);
        playerScores.Add("Player 2", 20);
        playerScores.Add("Player 3", 15);
        playerScores.Add("Player 4", 115);
        playerScores.Add("SoyManco991", 6);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int elementMax = playerScores.Values.Max();
            int elementMin = playerScores.Values.Min();
            string name = "";
            string name2 = "";
            foreach (var key in playerScores) {
                if(key.Value == elementMax) {
                     name = key.Key;
                }
                if(key.Value == elementMin) {
                    name2 = key.Key;
                }

            }


            Debug.Log("El que tiene mas Puntos es: " + name + ", El mas Noob es: " + name2);
        }
    }

}
