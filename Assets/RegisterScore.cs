using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScore : MonoBehaviour {

    public InputField nameField;
    public Button submitButton;
    int playerScore = PlayerScore.playerScore;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
	
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("score", playerScore);
        WWW www = new WWW("http://localhost/addscore.php", form);
        yield return www;   //Grab information and sit on it

        if (www.text == "0")
        {
            Debug.Log("Score submitted successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
        else
        {
            Debug.Log("Something happened with score submission.");
        }
    }

    public void VerifyName()
    {
        submitButton.interactable = (nameField.text.Length <= 10);
    }

}
