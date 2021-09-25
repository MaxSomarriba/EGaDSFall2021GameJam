using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgain_Script : MonoBehaviour
{
    public Image img;
    public static bool isImgOn;
    public float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        img.enabled = false;
        isImgOn = false;
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (isImgOn) {
            StartCoroutine(SpawnTimer());
        }
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
