using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public int EnemyID;

    public UnityEngine.UI.Text kanjiText, cheatText;
    public GameObject myEnemyObject;
    private EnemyObject myEnemy;
    RectTransform UI_Element;
    RectTransform canvas;
    private float timer;
    public string fullCheatString;
    private string cheatString;
    private int cheatStringCounter;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        cheatStringCounter = 0;
        cheatString = "";
        cheatText.text = cheatString;

        canvas = transform.root.GetComponent<RectTransform>();
        UI_Element = GetComponent<RectTransform>();
    }
    float cheatOpacity = 1f;
    // Update is called once per frame
    void Update()
    {
        if (!myEnemy)
        {
            if (myEnemyObject)
                myEnemy = myEnemyObject.transform.GetComponent<EnemyObject>();
        }


        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(myEnemyObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f)) + 64f);

        //now you can set the position of the ui element
        UI_Element.anchoredPosition = WorldObject_ScreenPosition;


        Hints();


    }

    private void Hints()
    {
        if (cheatStringCounter >= fullCheatString.Length)
        {
            cheatText.text = fullCheatString;
            cheatOpacity = 1f;
            cheatText.color = new Color(1f, 1f, 1f, cheatOpacity);
            return;
        }

        /////////

        timer += Time.deltaTime;

        if (timer > 2f + (3f * cheatStringCounter))
        {
            char n = fullCheatString[cheatStringCounter];
            cheatString += n;
            cheatStringCounter++;
            cheatText.text = cheatString;
            cheatOpacity = 1f;
            //Reduce the score
            myEnemy.ReduceScorePoints();
        }


        if (cheatOpacity > 0f)
            cheatOpacity -= Time.deltaTime;
        cheatText.color = new Color(1f, 1f, 1f, cheatOpacity);
    }
}
