using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryPaper_Script : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public int currentType;
    public static int selectedType;

    int[] types = {0, 1, 2};
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int random = UnityEngine.Random.Range(0, types.Length);
        currentType = types[random];
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = sprites[currentType];
    }

    public bool checkAnswer() {
        if (selectedType == currentType) {
            currentType = types[UnityEngine.Random.Range(0, types.Length)];
            PaperStack_Script.stackSize--;
            return true;
        } else {
            Debug.Log("Wrong type!");
            return false;
        }
    }

    void OnMouseDown() {
        checkAnswer();
    }

}
