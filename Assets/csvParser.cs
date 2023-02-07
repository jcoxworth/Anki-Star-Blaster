using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


//https://ankiweb.net/shared/info/1112021968
//https://www.youtube.com/watch?v=xwnL4meq-j8

public class csvParser : MonoBehaviour
{
    IDictionary<string, string> kanjiReading = new Dictionary<string, string>();

    public string kanjiSetFileName = "N2Kanji";
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
    }


    void ReadCSVFile()
    {
        //IDictionary<string, string> kanjiReading = new Dictionary<string, string>();

       // string m_Path = "C:/Users/zorgi/Desktop/Work/Anki Parser/Assets/anki_export.csv";
       string m_Path = Path.Combine(Application.streamingAssetsPath, kanjiSetFileName +".csv");
       // Debug.Log(m_Path);





          StreamReader strReader = new StreamReader(m_Path);
      //  StreamReader strReader = new StreamReader("C:\\Users/zorgi\\Desktop/Work\\Anki Parser\\Assets\\anki_export.csv");
        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }



            char comma = ","[0];
            var data_values = data_string.Split(comma);

            kanjiReading.Add(data_values[0].ToString(), data_values[1].ToString());

            KKManager kk = GetComponent<KKManager>();

            kk.kanji.Add(data_values[0].ToString());
            string readHiragana = KanaTools.kt.HiraganaToRomaji(data_values[1].ToString());
            //reading.Add(data_values[1].ToString());
            kk.reading.Add(readHiragana.ToUpper());

            kk.meaning.Add(data_values[2].ToString());
            

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
