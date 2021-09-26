using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeEntranceTrigger : MonoBehaviour
{
    public static bool isTriggered;

    void OnTriggerEnter2D(Collider2D ChangeScene) {
        SceneManager.LoadScene(sceneName: "OfficeScene");
        // Debug.Log("Triggered the office collider");
    }
}
