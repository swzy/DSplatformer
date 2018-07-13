using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	public bool hasDied;

	// Use this for initialization
	void Start () {
		hasDied = false;
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -7)
		{
			hasDied = true;
		}
		if (hasDied) {
			Die();
		}
	}
	void Die()
	{
        //Needs 'game over' and posts score/graphical text to a leaderboard.

        SceneManager.LoadScene("Main");
       // HSController.PostScores("name", PlayerScore.playerScore); //Uses static PostScore method to post the playerScore variable. NEED TO CREATE PLAYERNAME.
    }
}