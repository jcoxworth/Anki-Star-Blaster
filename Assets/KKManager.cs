using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KKManager : MonoBehaviour
{
    public static KKManager access;
    public List<string> kanji = new List<string>();
    public List<string> reading = new List<string>();
    public List<string> meaning = new List<string>();
    public List<string> levelKanji = new List<string>();
    public List<string> levelReading = new List<string>();
    public List<string> levelMeaning = new List<string>();
    public List<string> subLevelKanji = new List<string>();
    public List<string> subLevelReading = new List<string>();
    public List<string> subLevelMeaning = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        access = this;
    }
    private void Start()
    {

    }
    public void MakeNewLevel(int lvl)
    {
        levelKanji.Clear();
        levelReading.Clear();
        levelMeaning.Clear();

        if (kanji.Count < 1 && reading.Count < 1)
            return;

        for(int i = lvl; i < kanji.Count; i+=10)
        {
            levelKanji.Add(kanji[i]);
            levelReading.Add(reading[i]);
            levelMeaning.Add(meaning[i]);
        }
    }
    public void MakeNewSubLevel(int subLvl)
    {
        subLevelKanji.Clear();
        subLevelReading.Clear();
        subLevelMeaning.Clear();

        for (int i = subLvl; i < levelKanji.Count; i += 10)
        {
            subLevelKanji.Add(kanji[i]);
            subLevelReading.Add(reading[i]);
            subLevelMeaning.Add(meaning[i]);
        }
    }
}
