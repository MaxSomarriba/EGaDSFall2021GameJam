using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenEntranceTrigger : MonoBehaviour
{
    public static bool isTriggered;
    private GameObject playerScriptsUsedForReference;
    void Start()
    {
        playerScriptsUsedForReference = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D ChangeScene) {
        playerScriptsUsedForReference.GetComponent<playerScripts>().resetPosition();
        SceneManager.LoadScene(sceneName: "restaurantScene");
        // Debug.Log("Triggered the kitchen collider");
    }
}
