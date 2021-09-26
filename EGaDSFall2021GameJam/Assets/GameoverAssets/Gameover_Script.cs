using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover_Script : MonoBehaviour
{
    public GameObject Gameover;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameoverButton();
    }

    public void MainMenuButton()
    {
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