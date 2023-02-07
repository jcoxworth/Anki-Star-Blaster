using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoints : MonoBehaviour
{
    public static GamePoints access;
    GameManager gameManager;
    public int CurrentPoints;
    public int TotalPoints;

    public delegate void OnUpdateCurrentPoints();
    public OnUpdateCurrentPoints onUpdateCurrentPoints;
    public delegate void OnUpdateTotalPoints();
    public OnUpdateTotalPoints onUpdateTotalPoints;

    void Start()
    {
        access = this;
        gameManager = GetComponent<GameManager>();
        gameManager.onLevelIntro += ClearCurrentPoints;
        gameManager.onLevelFinished += UpdateTotalPoints;
        // gameManager.onMenu += SetMenuUI;
        //  gameManager.onLevelPlay += SetLevelPlayUI;
    }

    public void ClearCurrentPoints()
    {
        CurrentPoints = 0;
    }
    public void ChangeCurrentPoints(int amount)
    {
        CurrentPoints += amount;
        onUpdateCurrentPoints?.Invoke();
    }
    public void UpdateTotalPoints()
    {
        TotalPoints += CurrentPoints;
        ClearCurrentPoints();
        onUpdateTotalPoints?.Invoke();
    }
}
