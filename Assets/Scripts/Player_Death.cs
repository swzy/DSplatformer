using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour {

    public bool hasDied;
    public AudioSource deathNoise;

	// Use this for initialization
	void Start () {
        hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }
        if (hasDied) {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("DeathScreen");
        deathNoise.Play();
    }
}
