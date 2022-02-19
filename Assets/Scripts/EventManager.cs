using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    public static GameState currentGameState = GameState.Play;

    // Don't get any funny ideas just because I'm using lambda expressions () => {}
    // I still hate this things. Nobody use them!! >:(
    // Either way, all these events have to be filled with atleast one function in order to work properly,
    // So for now I just have them log the fact that they were fired
    #region All Events
    public static Action PauseEvent = () => {
        Debug.Log("Event Fired: Pause");
        currentGameState = GameState.Paused;
    };
    public static Action UnpauseEvent = () => {
        Debug.Log("Event Fired: Unpause");
        currentGameState = GameState.Play;
    };
    #endregion
}