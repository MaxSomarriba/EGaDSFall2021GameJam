using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class paitenceManagerScript : MonoBehaviour
{
    public int totalPaitence;
    private static paitenceManagerScript paitenceManagerInstance;
    public Text txt;

    public Sprite reallyHappy;
    public Sprite happy;
    public Sprite meh;
    public Sprite mad;
    public Sprite reallyMad;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (paitenceManagerInstance == null)
        {
            paitenceManagerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = totalPaitence.ToString();
        if (totalPaitence <= 0)
        {
            SceneManager.LoadScene(sceneName: "Gameover");
            DestroyObject(gameObject);
        }

        if(totalPaitence >= 80)
        {
            spriteRenderer.sprite = reallyHappy;
        }
        if(totalPaitence < 80 && totalPaitence >= 60)
        {
            spriteRenderer.sprite = happy;
        }
        if (totalPaitence < 60 && totalPaitence >= 40)
        {
            spriteRenderer.sprite = meh;
        }
        if (totalPaitence < 40 && totalPaitence >= 20)
        {
            spriteRenderer.sprite = mad;
        }
        if (totalPaitence < 20)
        {
            spriteRenderer.sprite = reallyMad;
        }
    }
    public void losePaitence(int amountOfPaitence)
    {
        totalPaitence -= amountOfPaitence;
    }
}
