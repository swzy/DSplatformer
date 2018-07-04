using UnityEngine;
using System.Collections;

public class enableCamera : MonoBehaviour {
    public Camera Overview;
    public Camera PlayerCamera;

    public void ShowPlayerView() {
        Overview.enabled = false;
        PlayerCamera.enabled = true;
    }
    
    public void ShowOverview() {
        Overview.enabled = true;
        PlayerCamera.enabled = false;
    }

    public void Start()
    {
    	ShowPlayerView();
    }
}
