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
    private int intialTimeBeforeLosingPaitenceAfterSittingDown;
    public int timeBeforeLosingMorePaitence;
    public int timeToEatFood;
    public int paitenceLost;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D _CircleCollider2D;
    public BoxCollider2D _BoxCollider2D;
    private AudioSource source;
    private static tableScript tableInstance;
    private GameObject associatedFoodWant;

    public GameObject pizzaFoodWant;
    public GameObject burgerFoodWant;
    public GameObject saladFoodWant;

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
        intialTimeBeforeLosingPaitenceAfterSittingDown = timeBeforeLosingPaitenceAfterSittingDown;
        _CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        _BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
        paitenceManagerScriptsUsedForLosingPaitence = GameObject.Find("PaitenceManager");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        DecideOrder();
        source = GetComponent<AudioSource>();
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
        

        whatIsPlayerHolding = playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding();
        //For trigger
        if (sceneName == "restaurantScene")
        {
            _BoxCollider2D.enabled = true;
            _CircleCollider2D.enabled = true;
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
            _BoxCollider2D.enabled = false;
            _CircleCollider2D.enabled = false;
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
        timeBeforeLosingPaitenceAfterSittingDown = intialTimeBeforeLosingPaitenceAfterSittingDown;
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
        source.Play();
        if (order == food.Pizza)
        {
            associatedFoodWant = Instantiate(pizzaFoodWant, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 1), Quaternion.identity);
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addPizza();
        }
        if (order == food.Burger)
        {
            associatedFoodWant = Instantiate(burgerFoodWant, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 1), Quaternion.identity);
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addBurger();
        }
        if (order == food.Salad)
        {
            associatedFoodWant = Instantiate(saladFoodWant, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z-1), Quaternion.identity);
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
        Destroy(associatedFoodWant);
        StopAllCoroutines();
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().resetHolding();
        EatFood();
        
    }
    public void EatFood()
    {
        TableState = tableState.Eating;
        StartCoroutine(EatFoodExecuteAfterTime(timeToEatFood));
    }
}
