using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoals : MonoBehaviour
{
    public int goalProgress = 0;
    public int goalSuccess = 3;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.access.onLevelIntro += ResetGoals;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeProgress()
    {
        goalProgress++;
        CheckGoalProgress();
    }
    public void ResetGoals()
    {
        goalProgress = 0;
    }
    public void CheckGoalProgress()
    {
        if (goalProgress >= goalSuccess)
        {
            GameManager.access.levelSucess = true;
            //load the finished state
            GameManager.access.LoadGameStateByInt(3);
            //unlock the next level
            GameManager.access.ProceedLevel();
        }
    }
}
