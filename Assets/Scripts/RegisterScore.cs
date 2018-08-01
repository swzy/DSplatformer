using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RegisterScore : MonoBehaviour {
    //This class is reponsible for sending scores in a C# form -> PHP script -> MySQL query that will post to a database specified in the PHP script.
    public InputField nameField;
    public Button submitButton;
    public Button backtoMainButton;
    public Text scoreDisplay;
    public Text scoreSubmissionText;
    public Text scoreNotSubmitText;
    int playerScore = Player_Score.playerScore;
    
    void Start()
    {
        scoreSubmissionText.GetComponent<Text>().enabled = false; //For scoreSubmitButton confirmation.
        scoreDisplayer();
    }

    public void CallRegister()
    {
        activateMessage();
        StartCoroutine(Register());
    }
	
    IEnumerator Register() //Registers username and score
    {
        WWWForm form = new WWWForm(); //Form that will hold the information to be sent.
        form.AddField("name", nameField.text);
        form.AddField("score", playerScore);

        Debug.Log(nameField.text + " " + playerScore);

        WWW www = new WWW("http://localhost/addscore.php", form); //If issues arise with score submission, PHP script is the likely culprit.
        yield return www;   //Grab information and sit on it
        yield return new WaitForSeconds(1); //Pauses CoRoutine for 1 second.
        SceneManager.LoadScene("Main Menu");
    }

    void scoreDisplayer()
    {
            scoreDisplay.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }
    public void exitMessage()
    {
        SceneManager.LoadScene("Main Menu");
    }
    void activateMessage()
    {
            scoreNotSubmitText.GetComponent<Text>().enabled = false;
            scoreSubmissionText.GetComponent<Text>().enabled = true;
    }

    public void VerifyName()
    {
        submitButton.interactable = (nameField.text.Length <= 10);
    }

    public void ResetScore()
    {
        Player_Score.playerScore = 0; //Resets game score.
    }

}
