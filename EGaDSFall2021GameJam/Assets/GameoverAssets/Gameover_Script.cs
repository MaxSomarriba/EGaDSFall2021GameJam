using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover_Script : MonoBehaviour
{
    public GameObject Gameover;
    public GameObject CreditsMenu;
    // private GameObject paitenceManagerUsedForReference;
    // private GameObject paperStackUsedForReference;

    // Start is called before the first frame update
    void Start()
    {
        // paitenceManagerUsedForReference = GameObject.Find("PaitenceManager");
        // paperStackUsedForReference = GameObject.Find("PaperStack");
        GameoverButton();
    }

    public void MainMenuButton()
    {
        // paitenceManagerUsedForReference.GetComponent<paitenceManagerScript>().gameRestart();
        // paperStackUsedForReference.GetComponent<PaperStack_Script>().gameRestart();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void CreditsButton()
    {
        Debug.Log("Clicked Credits");
        // Show Credits Menu
        Gameover.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void GameoverButton()
    {
        // Show Main Menu
        Gameover.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}