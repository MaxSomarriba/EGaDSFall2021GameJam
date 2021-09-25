using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option2_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        PrimaryPaper_Script.selectedType = 1;
        Debug.Log("Option 2 Selected");
    }
}
