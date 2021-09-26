using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tableScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    SpriteRenderer m_SpriteRenderer;
    public food order;
    private GameObject playerScriptsUsedForFoodReference;
    private GameObject paitenceManagerScriptsUsedForLosingPaitence;
    private holding whatIsPlayerHolding;
    public int timeBeforeLosingPaitenceAfterSittingDown;
    public int timeBeforeLosingMorePaitence;
    public int timeToEatFood;
    public int paitenceLost;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D _boxCollider2D;

    private static tableScript tableInstance;

    public enum food
    {
        Pizza,
        Burger,
        Salad
    }
    public enum tableState {
        Ordering,
        Waiting,
        Eating
    }
    public tableState TableState;

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
        paitenceManagerScriptsUsedForLosingPaitence = GameObject.Find("PaitenceManager");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        DecideOrder();
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (tableInstance == null)
        {
            tableInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (TableState == tableState.Ordering) {
            m_SpriteRenderer.color = Color.blue;
        }
        if (TableState == tableState.Waiting) {
            m_SpriteRenderer.color = Color.red;
        }
        if (TableState == tableState.Eating) {
            m_SpriteRenderer.color = Color.yellow;
        }

        whatIsPlayerHolding = playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding();
        //For trigger
        if (sceneName == "restaurantScene")
        {
            _boxCollider2D.enabled = true;
            spriteRenderer.enabled = true;
            if (triggerActive && Input.GetKeyDown(KeyCode.Space) && TableState == tableState.Ordering)
            {
                TakeOrder();
                
            }
            if (triggerActive && Input.GetKeyDown(KeyCode.Space) && TableState == tableState.Waiting && string.Equals(whatIsPlayerHolding.ToString(), order.ToString()))
            {
                TakeFood();
            }
        }
        else
        {
            _boxCollider2D.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (sceneName == "WinScene" || sceneName == "Gameover" || sceneName == "MainMenu")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        paitenceManagerScriptsUsedForLosingPaitence.GetComponent<paitenceManagerScript>().losePaitence(paitenceLost);
        
        StartCoroutine(ExecuteAfterTime(timeBeforeLosingMorePaitence));
    }
    IEnumerator EatFoodExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        TableState = tableState.Ordering;
        DecideOrder();
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
    public void TakeOrder()
    {

        if (order == food.Pizza)
        {
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addPizza();
        }
        if (order == food.Burger)
        {
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addBurger();
        }
        if (order == food.Salad)
        {
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addSalad();
        }
        TableState = tableState.Waiting;
    }

    public void DecideOrder()
    {
        StartCoroutine(ExecuteAfterTime(timeBeforeLosingPaitenceAfterSittingDown)); //start countdown
        order = GetRandomEnum<food>();
    }
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }
    public void TakeFood()
    {
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().resetHolding();
        EatFood();
    }
    public void EatFood()
    {
        TableState = tableState.Eating;
        StartCoroutine(EatFoodExecuteAfterTime(timeToEatFood));
    }
}
