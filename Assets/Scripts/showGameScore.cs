using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showGameScore : MonoBehaviour {
    int playerScore = Player_Score.playerScore;

    void Start()
    {
        gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }
}
