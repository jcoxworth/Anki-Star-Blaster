using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager access;

    public enum GameState { menu, levelIntro, levelPlay, levelFinished }
    public GameState currentGameState = GameState.menu;

    public delegate void OnMenu();
    public OnMenu onMenu;

    public delegate void OnLevelIntro();
    public OnLevelIntro onLevelIntro;

    public delegate void OnLevelPlay();
    public OnLevelPlay onLevelPlay;

    public delegate void OnLevelFinished();
    public OnLevelFinished onLevelFinished;


    public int CurrentLevel = 0;
    public int TotalLevels;
    public bool levelSucess = false;

    // Start is called before the first frame update
    void Awake()
    {
        access = this;
    }
    private void Start()
    {
        LoadGameStateByInt(0);
    }
    public void LevelMenu()
    {
        onMenu?.Invoke();
    }
    public void LevelIntro()
    {
        levelSucess = false;
        onLevelIntro?.Invoke();
    }
    public void LevelPlay()
    {
        onLevelPlay?.Invoke();
    }
    public void LevelFinished()
    {
        onLevelFinished?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        //debugging 
      //  if (Input.GetKeyDown(KeyCode.Space))
        //    AdvanceGameState();
    }


    public void ProceedLevel()
    {
        CurrentLevel++;
        if (CurrentLevel >= TotalLevels)
            CurrentLevel = 0;
    }

    public void AdvanceGameState()
    {
        int gamestateInt = (int)currentGameState;

        gamestateInt++;

        if (gamestateInt > 3)
            gamestateInt = 0;

        LoadGameStateByInt(gamestateInt);
    }
    public void LoadGameStateByInt(int state)
    {
        currentGameState = (GameState)state;
        switch(currentGameState)
        {
            case GameState.menu:
                LevelMenu();
                break;
            case GameState.levelIntro:
                LevelIntro();
                break;
            case GameState.levelPlay:
                LevelPlay();
                break;
            case GameState.levelFinished:
                LevelFinished();
                break;
        }
    }
}
