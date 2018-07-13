using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject highScorePanel;
    public GameObject textDisplay;

    void Start()
    {
        highScorePanel.SetActive(false);
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        highScorePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void HighScore()
    {
        highScorePanel.SetActive(true);
        displayScores();
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }

    public void displayScores()
    {
        string[] stream = HighScorePanelActivate.data;
        if (stream != null)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                // Because I can't get the string split to work, will just print out each row - SY

                //if (i % 3 == 0)
                //    textDisplayID.gameObject.GetComponent<Text>().text += (stream[i] + "\n");
                //else if (i % 3 == 1 && i != 0)
                //    textDisplayName.gameObject.GetComponent<Text>().text += (stream[i] + "\n");
                //else if (i % 2 == 0 && i != 0)
                //    textDisplayScore.gameObject.GetComponent<Text>().text += (stream[i] + "\n");

                textDisplay.gameObject.GetComponent<Text>().text += (stream[i] + "\n");

                Debug.Log("Stored in textDisplay variable.. " + i);
            }
        }
        else
            Debug.Log("No data to be displayed..");
    }
}
