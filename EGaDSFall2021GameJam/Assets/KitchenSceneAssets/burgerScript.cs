using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class burgerScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    private GameObject playerScriptsUsedForFoodReference;
    private holding whatIsPlayerHolding;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        whatIsPlayerHolding = playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "restaurantScene")
        {
            spriteRenderer.enabled = true;
            //For trigger
            if (triggerActive && Input.GetKeyDown(KeyCode.Space) && whatIsPlayerHolding == holding.Nothing)
            {
                //Debug.Log(playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding().GetType());
                burgerPickUp();
            }
        }else{
            spriteRenderer.enabled = false;
        }
        if (sceneName == "WinScene" || sceneName == "Gameover" || sceneName == "MainMenu")
        {
            Destroy(gameObject);
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }
    public void burgerPickUp()
    {
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().pickUpBurger();
        Destroy(gameObject);
    }
}
