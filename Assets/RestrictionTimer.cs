using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionTimer : MonoBehaviour
{
    public float currentTime;
    public float timeLimit = 10f;

    public TMPro.TMP_Text timeTXT;
    // Start is called before the first frame update
    void OnEnable()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }
    public void ResetTimer()
    {
        currentTime = 0f;
    }
    
    public void RunTimer()
    {
        if (GameManager.access.levelSucess)
            return;
        if (GameManager.access.currentGameState != GameManager.GameState.levelPlay)
            return;

        if (currentTime >= timeLimit)
        {
            GameManager.access.levelSucess = false;
            GameManager.access.LoadGameStateByInt(3);
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        if (timeTXT)
            timeTXT.text = "Time Left: " + (timeLimit - Mathf.Round(currentTime)).ToString();
    }
}
