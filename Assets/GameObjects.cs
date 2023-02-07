using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjects : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject menu, levelIntro, levelPlay, levelFinished;

    public GameObject[] levels;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.onMenu += SetMenuObjects;
        gameManager.onLevelIntro += SetLevelIntroObjects;
        gameManager.onLevelPlay += SetLevelPlayObjects;
        gameManager.onLevelFinished += SetLevelFinishedObjects;

        gameManager.TotalLevels = levels.Length;
        DeactivateAll();
    }
    private void DeactivateAll()
    {
        menu.SetActive(false);
        levelIntro.SetActive(false);
        levelPlay.SetActive(false);
        levelFinished.SetActive(false);

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
    }
    public void SetMenuObjects()
    {
        DeactivateAll();
        menu.SetActive(true);
    }

    public void SetLevelIntroObjects()
    {
        DeactivateAll();
        levelIntro.SetActive(true);
        levels[GameManager.access.CurrentLevel].SetActive(true);
    }
    public void SetLevelPlayObjects()
    {
        //DeactivateAll();
        levelPlay.SetActive(true);

    }
    public void SetLevelFinishedObjects()
    {
        //   DeactivateAll();
        levelPlay.SetActive(false);

        levelFinished.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
