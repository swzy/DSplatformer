using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startLevel;
    public string levelSelect;
    public string level1Tag;
    public string level2Tag;
    public string level3Tag;

    public void NewGame()
    {
        Player_Score.playerScore = 0; //Resets game score.
        PlayerPrefs.SetInt(level1Tag, 1);
        PlayerPrefs.SetInt(level2Tag, 0);
        PlayerPrefs.SetInt(level3Tag, 0);
        SceneManager.LoadScene(startLevel);
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt(level1Tag, 1);
        SceneManager.LoadScene(levelSelect);
        PlayerPrefs.SetInt(level2Tag, 0);
        PlayerPrefs.SetInt(level3Tag, 0);

        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
