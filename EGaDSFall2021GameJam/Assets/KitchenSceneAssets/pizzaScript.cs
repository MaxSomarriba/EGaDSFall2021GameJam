using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaScript : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    private GameObject playerScriptsUsedForFoodReference;
    private holding whatIsPlayerHolding;
    // Start is called before the first frame update
    void Start()
    {
        playerScriptsUsedForFoodReference = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        whatIsPlayerHolding = playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding();
        //For trigger
        if (triggerActive && Input.GetKeyDown(KeyCode.Space) && whatIsPlayerHolding == holding.Nothing)
        {
            //Debug.Log(playerScriptsUsedForFoodReference.GetComponent<playerScripts>().getCurrentHolding().GetType());
            pizzaPickUp();
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
    public void pizzaPickUp()
    {
        playerScriptsUsedForFoodReference.GetComponent<playerScripts>().pickUpPizza();
        Destroy(gameObject);
    }
}
