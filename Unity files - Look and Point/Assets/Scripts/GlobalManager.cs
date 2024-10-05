// using System.Collections;
// using System.Collections.Generic;
using System;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
  public static GlobalManager Instance; // Singleton
  public GameState State;
  public static event Action<GameState> OnGameStateChanged;

  public ExamineState examineState;

  void Awake()
  {
    Instance = this;
  }
  void Start()
  {
    UpdateGameState(GameState.InMenu);
  }

  void Update()
  {
    if (GameObject.Find("Menu_Camera") == null)
    {
      UpdateGameState(GameState.InRoom);
    }
  }

  public void UpdateGameState(GameState newState)
  {
    State = newState;

    switch (newState)
    {
      case GameState.InMenu:
        // handleInMenu();
        break;
      case GameState.InRoom:
        examineState.InRoom = true;
        break;
      case GameState.Inspecting:
        break;
      case GameState.InPuzzle:
        break;
      case GameState.EndScreen:
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }

    OnGameStateChanged?.Invoke(newState);
  }

}

public enum GameState
{
  InMenu,
  InRoom,
  Inspecting,
  InPuzzle,
  EndScreen
}
