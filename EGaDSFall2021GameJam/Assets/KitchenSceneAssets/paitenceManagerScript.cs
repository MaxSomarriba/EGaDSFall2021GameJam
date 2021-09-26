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
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public void losePaitence(int amountOfPaitence)
    {
        totalPaitence -= amountOfPaitence;
    }
}
