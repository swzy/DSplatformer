using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScore : MonoBehaviour {
    //This class is reponsible for sending scores in a C# form -> PHP script -> MySQL query that will post to a database specified in the PHP script.
    public InputField nameField;
    public Button submitButton;
    public Text scoreDisplay;
    public Text scoreSubmissionText;
    int playerScore = PlayerScore.playerScore;
    
    void Start()
    {
        if (scoreSubmissionText != null)
        scoreSubmissionText.GetComponent<Text>().enabled = false; //For scoreSubmitButton confirmation.
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
        scoreDisplayer();
        activateMessage();
    }
	
    IEnumerator Register()
    {
        WWWForm form = new WWWForm(); //Form that will hold the information to be sent.
        form.AddField("name", nameField.text);
        form.AddField("score", playerScore);

        Debug.Log(nameField.text + " " + playerScore);

        WWW www = new WWW("http://localhost/addscore.php", form); //If issues arise with score submission, PHP script is the likely culprit.
        yield return www;   //Grab information and sit on it
        yield return new WaitForSeconds(1); //Pauses CoRoutine for 1 second.

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    void scoreDisplayer()
    {
            scoreDisplay.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
    }
    void activateMessage()
    {
        if (scoreSubmissionText.GetComponent<Text>().enabled == false)
            scoreSubmissionText.GetComponent<Text>().enabled = true;
    }

    public void VerifyName()
    {
        submitButton.interactable = (nameField.text.Length <= 10);
    }

}
