using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private bool playerInZone;
    public string levelToLoad;
    public string levelTag;

	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone)
        {
            LoadLevel();
        }
	}

    public void LoadLevel()
    {
        PlayerPrefs.SetInt(levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInZone = false;
        }

    }

}
