using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public int cookingTime;
    public int pizzaToMake = 0;
    public int burgerToMake = 0;
    public int saladToMake = 0;
    public float foodCreationYOffset;
    public float spacingBetweenFoodCreation;
    private float initialFoodCreationYOffset;
    public int numberOfTables;
    public GameObject pizzaPrefab;
    public GameObject burgerPrefab;
    public GameObject saladPrefab;
    private GameObject playerScriptsUsedForFoodReference;
    // Start is called before the first frame update
    void Start()
    {
        initialFoodCreationYOffset = foodCreationYOffset;
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //For trigger
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            putOrdersIn();
            StartCoroutine(ExecuteAfterTime(cookingTime));
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
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if(pizzaToMake > 0)
        {
            createFood(pizzaPrefab);
            pizzaToMake--;
            StartCoroutine(ExecuteAfterTime(cookingTime));
        }
        else if(burgerToMake > 0)
        {
            createFood(burgerPrefab);
            burgerToMake--;
            StartCoroutine(ExecuteAfterTime(cookingTime));
        }
        else if (saladToMake > 0)
        {
            createFood(saladPrefab);
            saladToMake--;
            StartCoroutine(ExecuteAfterTime(cookingTime));
        }
    }
    public void putOrdersIn()
    {
        pizzaToMake += playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getPizza();
        burgerToMake += playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getBurger();
        saladToMake += playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getSalad();
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().clearOrders();
    }
    public void createFood(GameObject food)
    {
        Instantiate(food, new Vector3(transform.position.x - 3, transform.position.y + foodCreationYOffset, 0), Quaternion.identity);
        foodCreationYOffset -= spacingBetweenFoodCreation;
        if(foodCreationYOffset == -spacingBetweenFoodCreation * numberOfTables)
        {
            foodCreationYOffset = initialFoodCreationYOffset;
        }
    }
}
