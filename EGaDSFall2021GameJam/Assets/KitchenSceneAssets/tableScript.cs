using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    SpriteRenderer m_SpriteRenderer;
    public food order;
    private GameObject playerScriptsUsedForFoodReference;
    private GameObject paitenceManagerScriptsUsedForLosingPaitence;
    private holding whatIsPlayerHolding;
    public int timeBeforeLosingPaitenceAfterOrdering;
    public int timeBeforeLosingMorePaitence;
    public int paitenceLost;

    public enum food
    {
        Pizza,
        Burger,
        Salad
    }
    public enum tableState{
        Ordering,
        Waiting,
        Eating
    }
    public tableState TableState;

    // Start is called before the first frame update
    void Start()
    {
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
        paitenceManagerScriptsUsedForLosingPaitence = GameObject.Find("PaitenceManager");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        DecideOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if(TableState == tableState.Ordering){
            m_SpriteRenderer.color = Color.blue;
        }
        if (TableState == tableState.Waiting){
            m_SpriteRenderer.color = Color.red;
        }
        if (TableState == tableState.Eating){
            m_SpriteRenderer.color = Color.yellow;
        }

        whatIsPlayerHolding = playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding();
        //For trigger
        if (triggerActive && Input.GetKeyDown(KeyCode.Space) && TableState == tableState.Ordering)
        {
            TakeOrder();
            StartCoroutine(ExecuteAfterTime(timeBeforeLosingPaitenceAfterOrdering));
        }
        if (triggerActive && Input.GetKeyDown(KeyCode.Space) && TableState == tableState.Waiting && string.Equals(whatIsPlayerHolding.ToString(), order.ToString()))
        {
            TakeFood();
        }

    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        paitenceManagerScriptsUsedForLosingPaitence.GetComponent<paitenceManagerScript>().losePaitence(paitenceLost);
        if (TableState == tableState.Waiting)
        {
            StartCoroutine(ExecuteAfterTime(timeBeforeLosingMorePaitence));

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
        if(order == food.Salad)
        {
            playerScriptsUsedForFoodReference.GetComponent<playerScripts>().addSalad();
        }
        TableState = tableState.Waiting;
    }
    
    public void DecideOrder()
    {
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
        TableState = tableState.Eating;
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().resetHolding();
    }
}
