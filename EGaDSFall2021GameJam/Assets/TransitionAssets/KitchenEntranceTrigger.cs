using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenEntranceTrigger : MonoBehaviour
{
    public static bool isTriggered;

    void OnTriggerEnter2D(Collider2D ChangeScene) {
        SceneManager.LoadScene(sceneName: "restaurantScene");
        // Debug.Log("Triggered the kitchen collider");
    }
}
