using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showGameScore : MonoBehaviour {
    int playerScore = PlayerScore.playerScore;

    void Start()
    {
        gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }
}
