using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaperStack_Script : MonoBehaviour
{
    private static PaperStack_Script playerInstance;

    public static int stackSize = 10;
    public float TimeSeconds = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        if (sceneName == "WinScene" || sceneName == "Gameover" || sceneName == "MainMenu") {
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnTimer() {
        while (true) {
            yield return new WaitForSeconds(TimeSeconds);
            stackSize++;
            if (stackSize > 30) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover");
                Destroy(gameObject);
            }
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
