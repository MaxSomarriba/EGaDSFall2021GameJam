using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgain_Script : MonoBehaviour
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
        img.enabled = false;
        isImgOn = false;
        StartCoroutine(SpawnTimer());

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
            if (PrimaryPaper_Script.currentType == 0) {
                if (PrimaryPaper_Script.selectedType == 1) {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArraySign[3];
                } else {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArraySign[2];
                }
            } else if (PrimaryPaper_Script.currentType == 1) {
                if (PrimaryPaper_Script.selectedType == 0) {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStamp[3];
                } else {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStamp[2];
                }
            } else if (PrimaryPaper_Script.currentType == 2) {
                if (PrimaryPaper_Script.selectedType == 0) {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStaple[3];
                } else {
                    PrimaryPaper_Script.spriteRenderer.sprite = spriteArrayStamp[2];
                }
            }
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
