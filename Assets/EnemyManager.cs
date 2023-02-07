using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int maximumOnScreenEnemies = 3;
    public static EnemyManager access;
    public Transform uiCanvas;
    public GameObject blankEnemyUI;
    public GameObject blankEnemyObject;
    
    public List<GameObject> activeEnemyObjects = new List<GameObject>();
    public List<GameObject> activeEnemyUIs = new List<GameObject>();
    public List<string> activeEnemyReading = new List<string>();

    private LevelManager levelManager;


    public UnityEngine.UI.InputField inputField;

    public string inputString;

    //public Transform shooter;
   // public GameObject bullet;

    public int currentEnemyID = 0;

    public delegate void OnEnemyEscape();
    public OnEnemyEscape onEnemyEscape;

    public delegate void OnEnemyDefeated();
    public OnEnemyDefeated onEnemyDefeated;

    public Transform currentShootingTarget;

    private void Awake()
    {
        access = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        StartCoroutine(MakeEnemies());
        currentEnemyID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        inputString = inputField.text;
        if (Input.anyKeyDown)
            inputField.Select();
    }

    private IEnumerator MakeEnemies()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1f);
            if (activeEnemyObjects.Count < maximumOnScreenEnemies)
                MakeNewEnemy();
        }
    }
    public void FireText()
    {
        if (inputField.text != "")
            ShootActiveEnemies(inputField.text.ToUpper());

        inputField.text = "";
        inputField.ActivateInputField();
    }
    public void MakeNewEnemy()
    {
        //iterate to the next kanji, reading, and meaning from the list of level kanji
        levelManager.GetEnemyKanji();


        GameObject eObj = Instantiate(blankEnemyObject);
        GameObject eUI  = Instantiate(blankEnemyUI, uiCanvas);
        string eKanji = levelManager.currentKanji;
        string eReading = levelManager.currentReading;

        EnemyUI e = eUI.transform.GetComponent<EnemyUI>();
        e.fullCheatString = eReading;
        EnemyObject eo = eObj.transform.GetComponent<EnemyObject>();
        eo.enemyUI = e.gameObject;

        e.myEnemyObject = eObj;
        e.kanjiText.text = levelManager.currentKanji;
        eo.enemyReading = eReading;

        activeEnemyObjects.Add(eObj);
        activeEnemyUIs.Add(eUI);
        activeEnemyReading.Add(eReading);
    }
    public void DefeatEnemy()
    {
        onEnemyDefeated?.Invoke();
    }
    public void EscapedEnemy()
    {
        onEnemyEscape?.Invoke();
    }
    public void RemoveEnemyFromList(GameObject obj, GameObject ui, string readingString)
    {
        activeEnemyObjects.Remove(obj);
        activeEnemyUIs.Remove(ui);
        activeEnemyReading.Remove(readingString);
    }
    public void ShootActiveEnemies(string shotString)
    {
        for(int i = 0; i < activeEnemyObjects.Count; i++)
        {
            if (shotString == activeEnemyReading[i])
            {
                // GameObject toKill = activeEnemyObjects[i];
                //  activeEnemyObjects.Remove(activeEnemyObjects[i]);
                //  Destroy(activeEnemyObjects[i]);
                //  Destroy(activeEnemyUIs[i]);
                currentShootingTarget = activeEnemyObjects[i].transform;
               // shooter.transform.LookAt(activeEnemyObjects[i].transform.position - (Vector3.forward * 5f));
             //   Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
               // activeEnemyObjects.RemoveAt(i);
               // activeEnemyUIs.RemoveAt(i);
               // activeEnemyReading.RemoveAt(i);
            }
        }
    }
}
