using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anpanman : MonoBehaviour
{
    public UnityEngine.UI.Text kanjiText;
    public GameObject myEnemyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KKManager.access.kanji.Count > 0)
            kanjiText.text = KKManager.access.kanji[0];
    }
}
