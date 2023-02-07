using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameManager gameManager;
    private GamePoints gamePoints;
    public TMPro.TMP_Text currentPointsTXT, totalPointsTXT, levelCounterTXT;
    public GameObject menu, levelIntro, levelPlay, levelFinished, levelSuccess, levelFailure;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.onMenu += SetMenuUI;
        gameManager.onLevelIntro += SetLevelIntroUI;
        gameManager.onLevelIntro += UpdateAllPoints;

        gameManager.onLevelPlay += SetLevelPlayUI;
        gameManager.onLevelFinished += SetLevelFinishedUI;
        gameManager.onLevelFinished += UpdateAllPoints;

        gamePoints = GetComponent<GamePoints>();
        gamePoints.onUpdateCurrentPoints += UpdateCurrentPointsUI;
        gamePoints.onUpdateTotalPoints += UpdateTotalPointsUI;
        DeactivateAll();
        UpdateAllPoints();
    }

    public void UpdateAllPoints()
    {
        UpdateCurrentPointsUI();
        UpdateTotalPointsUI();
        UpdateLevelCounterUI();
    }
    public void UpdateCurrentPointsUI()
    {
        currentPointsTXT.text = gamePoints.CurrentPoints.ToString();
    }
    public void UpdateTotalPointsUI()
    {
        totalPointsTXT.text = gamePoints.TotalPoints.ToString();
    }
    public void UpdateLevelCounterUI()
    {
        levelCounterTXT.text = gameManager.CurrentLevel.ToString();
    }
    private void DeactivateAll()
    {
        menu.SetActive(false);
        levelIntro.SetActive(false);
        levelPlay.SetActive(false);
        levelFinished.SetActive(false);
    }
    public void SetMenuUI()
    {
        DeactivateAll();
        menu.SetActive(true);
    }

    public void SetLevelIntroUI()
    {
        DeactivateAll();
        levelIntro.SetActive(true);

    }
    public void SetLevelPlayUI()
    {
        DeactivateAll();
        levelPlay.SetActive(true);

    }
    public void SetLevelFinishedUI()
    {
        Debug.Log("level " + gameManager.levelSucess);
        levelSuccess.SetActive(gameManager.levelSucess);
        levelFailure.SetActive(!gameManager.levelSucess);
        DeactivateAll();
        levelFinished.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
