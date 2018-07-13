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

        data = request.text.Split(new char[] { '\n' });
        foreach (string s in data)
        {
            Debug.Log(s + " ");
        }
    }
    // I can't get this text splitter by whitespace to work. - SY

    //string[] Split(string[] input)
    //{
    //    string[] splitdata = new string[input.Length];
    //    foreach(string s in input)
    //    {
    //        splitdata = System.Text.RegularExpressions.Regex.Split(s, @"\s{1,}");
    //    }

    //    return splitdata;
    //}
}
