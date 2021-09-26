using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCountdown_Script : MonoBehaviour
{
private static WinCountdown_Script playerInstance;

    public int timeLeft =  120;

    public float timeSeconds = 1;

    public Text timeLeftText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftText.text = timeLeft.ToString();
        StartCoroutine(SpawnWinTimer());
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftText.text = timeLeft.ToString();

        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        if (sceneName == "WinScene" || sceneName == "Gameover" || sceneName == "MainMenu") {
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnWinTimer() {
        while (true) {
            yield return new WaitForSeconds(timeSeconds);
            timeLeft--;
            if (timeLeft <= 0) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
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
            Destroy(gameObject);
        }
    }
}
