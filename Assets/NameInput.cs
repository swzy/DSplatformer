using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {
    public string playerName;
	// Update is called once per frame
	void Update () {
        playerName = gameObject.GetComponent<Text>().text;
    }
}
