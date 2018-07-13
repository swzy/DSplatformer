//using UnityEngine;
//using System;
//using System.Collections;

//public class HSController : MonoBehaviour
//{
//    public static string addScoreURL = "http://localhost/addscore.php?"; //be sure to add a ? to your url
//    public static string highscoreURL = "http://localhost/display.php";
//    public static ArrayList scoreboardElements = new ArrayList();

//    void Start()
//    {
//        StartCoroutine(GetScores());
//    }

//    // remember to use StartCoroutine when calling this function!
//    public static IEnumerator PostScores(string name, int score)
//    {
//        //This connects to a server side php script that will add the name and score to a MySQL DB.
//        // Supply it with a string representing the players name and the players score.

//        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score;

//        // Post the URL to the site and create a download object to get the result.
//        WWW hs_post = new WWW(post_url);
//        yield return hs_post; // Wait until the download is done

//        if (hs_post.error != null)
//        {
//            print("There was an error posting the high score: " + hs_post.error);
//        }
//    }

//    // Get the scores from the MySQL DB to display in a GUIText.
//    // remember to use StartCoroutine when calling this function!
//    public static IEnumerator GetScores()
//    {
//        WWW scores = new WWW(highscoreURL);
        
//        yield return scores;

//        Debug.Log(scores.error);
//        Debug.Log(scores.text);

//        string[] data = scores.text.Split(new char[] { '\n' }); //Logic for how lines will be read and stored
//        if (data == null)
//        {
//            Debug.Log("No data is being retrieved..?");

//        }
//        if (scores.error != null)
//        {
//            print("There was an error getting the high score: " + scores.error);
//        }
//        else
//        {
//            foreach (string element in data)
//            {
//                if (string.IsNullOrEmpty(element.Trim()))
//                {
//                    continue;
//                }
//                else
//                {
//                    scoreboardElements.Add(element);
//                }

//                Debug.Log("PHP data: " + element);
//            }
//        }
//    }
//}