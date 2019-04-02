using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {


    public static StateManager Instance { get; private set; }

    public delegate void GameStateChangeAction(GameState state);
    public static GameStateChangeAction OnGameStateChanged;


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
                    // OnGameStateChanged(currentState);
                    OnGameStateChanged.Invoke(currentState);
                }
            }
        }
    }

    #region Unity Messages

    private void OnEnable()
    {
        TitleScreenBehaviour titleScreen = FindObjectOfType<TitleScreenBehaviour>();
        if (titleScreen)
        {
            titleScreen.OnStartGamePressed += HandleOnStartGamePressed;
        }
    }

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
        CurrentState = GameState.TitleScreen;
    }

    #endregion


    void HandleOnStartGamePressed()
    {
        Debug.Log("Start Game was pressed");
        CurrentState = GameState.Playing;
    }
}
