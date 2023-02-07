using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager access;

    public int Level = 0;
    public int HealthPoints = 3;
    public int SubLevel = 0;
    public int LevelPoints = 0;

    public UnityEngine.UI.Text pointsTXT;
    public delegate void OnNewLevelStart();
    public OnNewLevelStart onNewLevelStart;

    public delegate void OnPlayerHit();
    public OnPlayerHit onPlayerHit;
    public delegate void OnGameOver();
    public OnGameOver onGameOver;

    public int currentKanjiCount = 0;
    public int maxKanjiCount = 0;

    private KKManager kKManager;

    public string currentKanji;
    public string currentReading;
    public string currentMeaning;
    // Start is called before the first frame update
    void Awake()
    {
        access = this;
        HealthPoints = 3;
    }
    private void Start()
    {
        kKManager = GetComponent<KKManager>();
        GetComponent<EnemyManager>().onEnemyEscape += PlayerHit;
        LoadNewLevel();
    }
    public void LoadNewLevel()
    {
        GetComponent<KKManager>().MakeNewLevel(Level);
        GetComponent<KKManager>().MakeNewSubLevel(SubLevel);
        currentKanjiCount = Random.Range(0, maxKanjiCount);

        maxKanjiCount = kKManager.subLevelKanji.Count;
    }
    
    public void StartNewLevel()
    {
        onNewLevelStart?.Invoke();
    }

    public void GetEnemyKanji()
    {


        if (kKManager.levelKanji.Count < 1)
            LoadNewLevel();

        currentKanji = kKManager.subLevelKanji[currentKanjiCount];
        currentReading = kKManager.subLevelReading[currentKanjiCount];
        currentMeaning = kKManager.subLevelMeaning[currentKanjiCount];

        currentKanjiCount++;
        if (currentKanjiCount >= maxKanjiCount)
        {
            currentKanjiCount = 0;
            NextSublevel();
        }
    }
    public void NextSublevel()
    {
        SubLevel++;
        LoadNewLevel();
    }
    public void GetPoints(int amount)
    {
        LevelPoints += amount;
        pointsTXT.text = LevelPoints.ToString();
    }
    public void PlayerHit()
    {
        ChangeHealth(-1);
    }
    public void ChangeHealth(int amount)
    {
        HealthPoints += amount;
        if (amount < 0)
            onPlayerHit?.Invoke();
        if (HealthPoints <= 0)
        {
            onGameOver?.Invoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
