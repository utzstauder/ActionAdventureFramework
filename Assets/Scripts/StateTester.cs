using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTester : MonoBehaviour {

    private void OnEnable()
    {
        StateManager.OnGameStateChanged -= HandleOnGameStateChanged;
        StateManager.OnGameStateChanged += HandleOnGameStateChanged;
    }

    private void OnDisable()
    {
        StateManager.OnGameStateChanged -= HandleOnGameStateChanged;
    }

    void HandleOnGameStateChanged(StateManager.GameState targetState)
    {
        Debug.Log(targetState);
        Debug.Log((int)targetState);
    }
}
