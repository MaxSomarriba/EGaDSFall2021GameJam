using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Correct_Script : MonoBehaviour
{
    public Image img;
    public static bool isImgOn;
    public float time = 1f;

    public Sprite[] spriteArraySign;
    public Sprite[] spriteArrayStamp;
    public Sprite[] spriteArrayStaple;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
        img.enabled = false;
        isImgOn = false;

        spriteArraySign = Resources.LoadAll<Sprite>("signPapers");
        spriteArrayStamp = Resources.LoadAll<Sprite>("stampPapers");
        spriteArrayStaple = Resources.LoadAll<Sprite>("staplePapers");
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
            /*
            if (PrimaryPaper_Script.currentType == 0) {
                PrimaryPaper_Script.spriteRenderer.sprite = spriteArraySign[1];
            } else if (PrimaryPaper_Script.currentType == 1) {
                PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStamp[1];
            } else {
                PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStaple[1];
            }
            */
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
