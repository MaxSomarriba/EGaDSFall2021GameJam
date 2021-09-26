using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Script : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    private GameObject paitenceManagerUsedForReference;
    private GameObject paperStackUsedForReference;

    // Start is called before the first frame update
    void Start()
    {
        paitenceManagerUsedForReference = GameObject.Find("PaitenceManager");
        paperStackUsedForReference = GameObject.Find("PaperStack");
        MainMenuButton();

    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("OfficeScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene("restaurantScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene("TransitionScene");
        paitenceManagerUsedForReference.GetComponent<paitenceManagerScript>().gameRestart();
        paperStackUsedForReference.GetComponent<PaperStack_Script>().gameRestart();
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}