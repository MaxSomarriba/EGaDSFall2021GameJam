using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperStackUI_Script : MonoBehaviour
{
    public Text stackSizeText;
    // Start is called before the first frame update
    void Start()
    {
        stackSizeText.text = PaperStack_Script.stackSize.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        stackSizeText.text = PaperStack_Script.stackSize.ToString();
    }
}
