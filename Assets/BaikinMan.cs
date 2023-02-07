using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaikinMan : MonoBehaviour
{
    public UnityEngine.UI.InputField inputField;

    public string inputString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputString = inputField.text;
        if (Input.anyKeyDown)
            inputField.Select();
        
    }
    public void FireText()
    {
        if (inputField.text != "")
            Debug.Log("Input fired");

        inputField.text = "";
        inputField.ActivateInputField(); 

    }
}
