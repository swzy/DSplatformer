using System.Collections;
using UnityEngine;

public class HighScorePanelActivate : MonoBehaviour
{

    public static string[] data;

    // Use this for initialization
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/display.php");
        yield return request;

        data = request.text.Split(new char[0]);
        //Use the below foreach to debug the data retrieval.

        foreach (string s in data)
        {
            Debug.Log(s + " ");
        }
    }
}
