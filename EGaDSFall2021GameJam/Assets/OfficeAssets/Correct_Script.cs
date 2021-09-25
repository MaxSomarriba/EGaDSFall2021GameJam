using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Correct_Script : MonoBehaviour
{
    public Image img;
    public static bool isImgOn;
    public float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
        img.enabled = false;
        isImgOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer() {
        if (isImgOn) {
            show();
            yield return new WaitForSeconds(time);
            hide();
        }
    }

    void show() {
        img.enabled = true;
    }

    void hide() {
        img.enabled = false;
        isImgOn = false;
    }
}
