using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class paitenceManagerScript : MonoBehaviour
{
    public int totalPaitence;
    private static paitenceManagerScript paitenceManagerInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (paitenceManagerInstance == null)
        {
            paitenceManagerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(totalPaitence <= 0)
        {
            Debug.Log("YOU LOSE");
        }
    }
    public void losePaitence(int amountOfPaitence)
    {
        totalPaitence -= amountOfPaitence;
    }
}
