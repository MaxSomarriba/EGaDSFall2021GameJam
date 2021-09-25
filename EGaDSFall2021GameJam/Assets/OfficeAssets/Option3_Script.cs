using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option3_Script : MonoBehaviour
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
        PrimaryPaper_Script.selectedType = 2;
        Debug.Log("Option 3 Selected");
    }
}
