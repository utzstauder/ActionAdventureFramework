using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBehaviour : MonoBehaviour {

    public System.Action OnStartGamePressed;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
	}

    void StartGame()
    {
        // notify about event
        if (OnStartGamePressed != null)
        {
            OnStartGamePressed();
        }

        // disable script
        this.enabled = false;
    }
}
