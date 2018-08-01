using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //Class that controls in-game pause menu and pulling MySQL entries for high score list.

    public static bool GameIsPaused = false;
    public bool scorePull = false;
    public GameObject pauseMenuUI;
    public GameObject highScorePanel;
    public GameObject textDisplayID, textDisplayName, textDisplayScore;

    void Start()
    {
        highScorePanel.SetActive(false); //Because highScorePanel is in the same canvas as pause menu, activation must be organized.
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
    public void levelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }

    public void displayScores()
    {
        if (scorePull == true)
        {
            //Janky way of clearing out the text Objects.
            textDisplayID.gameObject.GetComponent<Text>().text = "";
            textDisplayName.gameObject.GetComponent<Text>().text = "";
            textDisplayScore.gameObject.GetComponent<Text>().text = "";
        }
        string[] stream = HighScorePanelActivate.data;
        if (stream != null)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                if (i % 3 == 0)
                    textDisplayID.gameObject.GetComponent<Text>().text += (stream[i] + "\n");
                else if (i % 3 == 1 && i != 0)
                    textDisplayName.gameObject.GetComponent<Text>().text += (stream[i] + "\n");
                else if (i % 3 == 2 && i != 0)
                    textDisplayScore.gameObject.GetComponent<Text>().text += (stream[i] + "\n");

                //textDisplay.gameObject.GetComponent<Text>().text += (stream[i] + "\n"); Keeping here just in case.

                Debug.Log("Stored in textDisplay variable.. " + i);
            }
            scorePull = true;
        }
        else
            Debug.Log("No data to be displayed..");
    }
}
