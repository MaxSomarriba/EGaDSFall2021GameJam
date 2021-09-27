using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryPaper_Script : MonoBehaviour
{
    public static SpriteRenderer spriteRenderer;

    public static int currentType;
    public static int selectedType;

    int[] types = {0, 1, 2};

    public Sprite[] sprites;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int random = UnityEngine.Random.Range(0, types.Length);
        currentType = types[random];

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PaperStack_Script.stackSize == 0) {
            spriteRenderer.enabled = false;
        } else {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = sprites[currentType];
        }
    }

    public bool checkAnswer() {
        if (selectedType == currentType) {
            Correct_Script.isImgOn = true;
            currentType = types[UnityEngine.Random.Range(0, types.Length)];
            if (PaperStack_Script.stackSize > 0) {
                PaperStack_Script.stackSize--;
                source.Play();
            }
            return true;
        } else {
            TryAgain_Script.isImgOn = true;
            return false;
        }
    }

    void OnMouseDown() {
        checkAnswer();
    }

}
