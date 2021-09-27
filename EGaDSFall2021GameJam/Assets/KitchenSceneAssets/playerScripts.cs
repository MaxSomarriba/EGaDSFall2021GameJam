using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Holding
public enum holding
{
    Nothing,
    Pizza,
    Burger,
    Salad
}
public class playerScripts : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    int[] types = { 0, 1, 2 , 3, 4, 5, 6, 7, 8, 9, 10, 11};
    int currentType = 0;
    public Sprite[] sprites;
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;


    public holding isHolding;
    //ordering
    public int pizza = 0;
    public int burger = 0;
    public int salad = 0;

    private static playerScripts playerInstance;
    public BoxCollider2D _boxCollider2D;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            DestroyObject(gameObject);
        }
    }

    void Update()
    {

        spriteRenderer.sprite = sprites[currentType];
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "restaurantScene")
        {
            spriteRenderer.enabled = true;
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
            if(horizontal == 0 && vertical == 0 && (pizza == 0 && burger == 0 && salad == 0) && isHolding == holding.Nothing)
            {
                currentType = 0;
            }
            if (horizontal == 0 && vertical == -1 && (pizza == 0 && burger == 0 && salad == 0) && isHolding == holding.Nothing)
            {
                currentType = 0;
            }
            if (horizontal == 0 && vertical == 1 && (pizza == 0 && burger == 0 && salad == 0) && isHolding == holding.Nothing)
            {
                currentType = 1;
            }
            if (horizontal == -1 && vertical == 0 && (pizza == 0 && burger == 0 && salad == 0) && isHolding == holding.Nothing)
            {
                currentType = 6;
            }
            if (horizontal == 1 && vertical == 0 && (pizza == 0 && burger == 0 && salad == 0) && isHolding == holding.Nothing)
            {
                currentType = 7;
            }
            //HOLDING ORDERS
            if (horizontal == 0 && vertical == 0 && (pizza > 0 || burger > 0 || salad > 0) && isHolding == holding.Nothing)
            {
                currentType = 2;
            }
            if (horizontal == 0 && vertical == -1 && (pizza > 0 || burger > 0 || salad > 0) && isHolding == holding.Nothing)
            {
                currentType = 2;
            }
            if (horizontal == 0 && vertical == 1 && (pizza > 0 || burger > 0 || salad > 0) && isHolding == holding.Nothing)
            {
                currentType = 3;
            }
            if (horizontal == -1 && vertical == 0 && (pizza > 0 || burger > 0 || salad > 0) && isHolding == holding.Nothing)
            {
                currentType = 8;
            }
            if (horizontal == 1 && vertical == 0 && (pizza > 0 || burger > 0 || salad > 0) && isHolding == holding.Nothing) 
            {
                currentType = 9;
            }
            //HOLDING FOOD
            if (horizontal == 0 && vertical == 0 && isHolding != holding.Nothing)
            {
                currentType = 4;
            }
            if (horizontal == 0 && vertical == -1 && isHolding != holding.Nothing)
            {
                currentType = 4;
            }
            if (horizontal == 0 && vertical == 1 && isHolding != holding.Nothing)
            {
                currentType = 5;
            }
            if (horizontal == -1 && vertical == 0 && isHolding != holding.Nothing)
            {
                currentType = 10;
            }
            if (horizontal == 1 && vertical == 0 && isHolding != holding.Nothing)
            {
                currentType = 11;
            }


        }
        else
        {
            spriteRenderer.enabled = false;
            horizontal = 0;
            vertical = 0;
        }
        if (sceneName == "WinScene" || sceneName == "Gameover" || sceneName == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    public void addPizza()
    {
        pizza++;
    }
    public void addBurger()
    {
        burger++;
    }
    public void addSalad()
    {
        salad++;
    }
    public int getPizza()
    {
        return pizza;
    }
    public int getBurger()
    {
        return burger;
    }
    public int getSalad()
    {
        return salad;
    }
    public void clearOrders()
    {
        pizza = 0;
        burger = 0;
        salad = 0;
    }
    public holding getCurrentHolding()
    {
        return isHolding;
    }
    public void resetHolding()
    {
        isHolding = holding.Nothing;
    }
    public void pickUpPizza()
    {
        isHolding = holding.Pizza;
    }
    public void pickUpBurger()
    {
        isHolding = holding.Burger;
    }
    public void pickUpSalad()
    {
        isHolding = holding.Salad;
    }

    public void resetPosition()
    {
        gameObject.transform.position = new Vector3(-5 , 0, 0);
    }
}
