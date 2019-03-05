using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {


    public static StateManager Instance { get; private set; }

    public static System.Action<GameState> OnGameStateChanged;


    // int currentState = 0; BAD

    public enum GameState
    {
        Initializing,
        TitleScreen,
        Playing,
        Paused,
        Quitting
    }

    private GameState currentState;

    public GameState CurrentState {
        get
        {
            return currentState;
        }
        private set
        {
            if (value != currentState)
            {
                currentState = value;
                if (OnGameStateChanged != null)
                {
                    OnGameStateChanged(currentState);
                }
            }
        }
    }


    #region Unity Messages

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurrentState = GameState.Playing;
        CurrentState = GameState.Paused;
    }

    #endregion
}
